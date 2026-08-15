using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using StudioElevenLib.Level5.Text;
using Nyanko.Forms;

namespace Nyanko
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args == null || args.Length == 0)
            {
                Application.Run(new NyankoWindow());
                return;
            }

            // The file path is always the first argument
            string filePath = args[0];

            if (args.Length == 1)
            {
                // Only a file path was given: try to open the app directly with it.
                // Any unsupported extension or error is silently ignored inside NyankoWindow, the app just starts normally.
                Application.Run(new NyankoWindow(filePath));
                return;
            }

            // Parse the remaining arguments (order doesn't matter, only the file path must come first)
            bool hasConvert = false;
            string convertMode = null;
            string outputPath = null;
            bool varianceKey = false;
            bool listKey = false;
            bool hasLock = false;
            string lockMode = null;
            bool hasGoto = false;
            string gotoType = null;
            int gotoId = 0;
            int gotoVariance = 0;

            for (int i = 1; i < args.Length; i++)
            {
                string flag = NormalizeFlagAlias(args[i]);

                switch (flag)
                {
                    case "-c":
                        hasConvert = true;
                        if (i + 1 < args.Length)
                        {
                            convertMode = NormalizeModeAlias(args[i + 1]);
                            i++;
                        }
                        break;

                    case "-o":
                        if (i + 1 < args.Length)
                        {
                            outputPath = args[i + 1];
                            i++;
                        }
                        break;

                    case "-vk":
                        varianceKey = true;
                        break;

                    case "-lk":
                        listKey = true;
                        break;

                    case "-l":
                        hasLock = true;
                        if (i + 1 < args.Length)
                        {
                            lockMode = NormalizeModeAlias(args[i + 1]);
                            i++;
                        }
                        break;

                    case "-g":
                        {
                            // -g [textType] [textId] [variance] : variance is optional, defaults to 0
                            string typeToken = (i + 1 < args.Length) ? args[i + 1] : null;
                            string idToken = (i + 2 < args.Length) ? args[i + 2] : null;

                            string normalizedType = NormalizeGotoTypeAlias(typeToken);

                            if (normalizedType != null && idToken != null)
                            {
                                hasGoto = true;
                                gotoType = normalizedType;
                                gotoId = ParseId(idToken);
                                i += 2;

                                // Only consume the next token as the variance if it's actually a valid non-negative integer
                                if (i + 1 < args.Length &&
                                    long.TryParse(args[i + 1], out long parsedVariance) &&
                                    parsedVariance >= 0 && parsedVariance <= int.MaxValue)
                                {
                                    gotoVariance = (int)parsedVariance;
                                    i++;
                                }
                            }
                        }
                        break;

                    default:
                        // Shorthand mode flags like "-x" or "-t" act as an implicit "-c x" / "-c t"
                        if (flag.StartsWith("-"))
                        {
                            string shorthandMode = NormalizeModeAlias(flag.TrimStart('-'));
                            if (shorthandMode != null)
                            {
                                hasConvert = true;
                                convertMode = shorthandMode;
                            }
                        }
                        break;
                }
            }

            // -c takes priority over -l and -g: when -c is present, both are ignored entirely.
            // When -l is present (without -c), -vk, -lk and -o are ignored entirely.
            if (hasConvert)
            {
                hasLock = false;
                lockMode = null;
                hasGoto = false;
                gotoType = null;
            }
            else if (hasLock)
            {
                outputPath = null;
                varianceKey = false;
                listKey = false;
            }

            if (hasConvert)
            {
                if (convertMode != null)
                {
                    ConvertFileFromCommandLine(filePath, convertMode, outputPath, varianceKey, listKey);
                }
                // Headless conversion: the main window is never shown
                return;
            }

            // -l and -g can coexist (they only conflict with -c, handled above)
            Application.Run(new NyankoWindow(
                filePath,
                hasLock,
                hasLock ? (lockMode ?? "b") : null,
                hasGoto ? gotoType : null,
                hasGoto ? (int?)gotoId : null,
                gotoVariance));
        }

        // Maps long-form flag aliases to their short canonical form
        private static string NormalizeFlagAlias(string value)
        {
            switch (value)
            {
                case "--convert": return "-c";
                case "--varianceKey": return "-vk";
                case "--listKey": return "-lk";
                case "--lock": return "-l";
                case "--goto": return "-g";
                default: return value;
            }
        }

        // Maps mode aliases (binary/binaryTextConfig/xml/txt) to their short canonical form (b/bt/x/t)
        private static string NormalizeModeAlias(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            switch (value.Trim().ToLowerInvariant())
            {
                case "b":
                case "binary":
                    return "b";
                case "bt":
                case "binarytextconfig":
                    return "bt";
                case "x":
                case "xml":
                    return "x";
                case "t":
                case "txt":
                    return "t";
                default:
                    return null;
            }
        }

        // Maps -g text type aliases (debug/noun/text) to their short canonical form (d/n/t)
        private static string NormalizeGotoTypeAlias(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            switch (value.Trim().ToLowerInvariant())
            {
                case "d":
                case "debug":
                    return "d";
                case "n":
                case "noun":
                    return "n";
                case "t":
                case "text":
                    return "t";
                default:
                    return null;
            }
        }

        private static int ParseId(string idText)
        {
            // Parses an ID that can be either an already-computed crc32 in hex form (e.g. 0x6B87BE96, value taken directly),
            // or plain text, in which case its crc32 is computed. Used for both -g's textId and character IDs.

            if (string.IsNullOrEmpty(idText)) return 0;

            if (idText.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                string hexPart = idText.Substring(2);
                return unchecked((int)Convert.ToUInt32(hexPart, 16));
            }

            return unchecked((int)StudioElevenLib.Tools.Crc32.Compute(Encoding.UTF8.GetBytes(idText)));
        }

        private static void ConvertFileFromCommandLine(string filePath, string mode, string outputPath, bool varianceKey, bool listKey)
        {
            // Performs a direct, headless conversion of a single file from the command line.
            // No variance key / key list support and no output path override unless explicitly given.

            try
            {
                T2bþ file = LoadT2bFile(filePath);
                if (file == null) return;

                switch (mode)
                {
                    case "b":
                        file.Encoding = Encoding.UTF8;
                        file.Save(outputPath ?? GetDefaultOutputPath(filePath, ".cfg.bin"), false, varianceKey, listKey);
                        break;

                    case "bt":
                        file.Encoding = Encoding.UTF8;
                        file.Save(outputPath ?? GetDefaultOutputPath(filePath, ".cfg.bin"), true, varianceKey, listKey);
                        break;

                    case "t":
                        File.WriteAllLines(outputPath ?? GetDefaultOutputPath(filePath, ".txt"), file.ExportToTxt());
                        break;

                    case "x":
                        File.WriteAllLines(outputPath ?? GetDefaultOutputPath(filePath, ".xml"), file.ExportToXML());
                        break;
                }
            }
            catch
            {
                // Ignor error
            }
        }

        private static T2bþ LoadT2bFile(string filePath)
        {
            if (filePath.EndsWith(".bin", StringComparison.OrdinalIgnoreCase))
                return new T2bþ(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            if (filePath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                return new T2bþ(File.ReadAllLines(filePath));
            if (filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                return new T2bþ(File.ReadAllText(filePath));
            return null;
        }

        private static string GetDefaultOutputPath(string inputFilePath, string newExtension)
        {
            string directory = Path.GetDirectoryName(inputFilePath) ?? string.Empty;
            string baseName = Regex.Replace(Path.GetFileName(inputFilePath), @"\..+$", string.Empty);
            return Path.Combine(directory, baseName + newExtension);
        }
    }
}