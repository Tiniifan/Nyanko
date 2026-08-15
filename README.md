# [Nyanko](https://github.com/Tiniifan/Nyanko/releases/latest) <img src="https://github.com/Tiniifan/Nyanko/blob/main/Nyanko/Icon/Icon.png" alt="Logo" width="5%">

---

**What is a cfg.bin file?**

The cfg.bin files (or simply .bin files) are binary files used in some Level-5 games.

These files are compiled binaries structured like tags that store various game variables.

In addition to standard primitive data types (integers, floats, etc.), these files contain text data.

Nyanko is a tool built upon [CfgBinEditor](https://github.com/Tiniifan/CfgBinEditor) that focuses specifically on text editing to make localized modifications effortless.

**Supported Text Types**

Nyanko supports **3 types of text categories**:

* **Noun**
* **Text**
* **TextDebug**

**Tested on**

* Inazuma Eleven GO ✅
* Inazuma Eleven GO 2 ✅
* Inazuma Eleven GO 3 ✅
* Yo-Kai Watch 1 ✅
* Yo-Kai Watch 4 ✅
* Ni no Kuni 2✅

**Supported Files & Formats**

* **.bin** and **.cfg.bin** (Level-5 binary format)
* **.txt**
* **Regular format**
```text
Texte 1
Texte 2
Texte 3
```

* **Nyanko format** (Nyanko always exports using this format so your file doesn't lose any metadata!)
Header format: `[TextType/IdText/IdSpeaker]`
`IdText` can be represented either as a hexadecimal CRC32 hash (e.g. `0x05927998`) or as a readable text ID string (e.g. `ev10`).
```text
[Texts/0x05927998/0xD9CF42CC] 
[0; 0] First dialogbox
[0; 1] Variance text for first dialogbox
[1; 0] Second dialog box

[Texts/ev10/0xD9CF42CC]
[0; 0] Dialogue for event 10

[Nouns/0x0616ADF6/0xD714CAFE] 
[0; 0] Noun 1

[DebugTexts/0x12345678/0xFFFFFFFF]
[0; 0] Debug message 1
```
* **.xml**
```xml
<?xml version="1.0" encoding="utf-8"?>
<Root>
    <Texts>
      <TextConfig crc32="0x8A8209CC" washa="0xFFFFFFFF">
        <String textNumber="0" varianceKey="0" value="First dialogbox" />
        <String textNumber="0" varianceKey="1" value="Variance text for first dialogbox" />
        <String textNumber="1" varianceKey="0" value="Second dialog box" />
      </TextConfig>
      <TextConfig crc32="ev10" washa="0xFFFFFFFF">
        <String textNumber="0" varianceKey="0" value="Dialogue for event 10" />
      </TextConfig>
    </Texts>
    <Nouns>
      <TextConfig crc32="0x4DED3A46" washa="0xFFFFFFFF">
        <String textNumber="0" varianceKey="0" value="Samguk Han" />
      </TextConfig>
    </Nouns>
    <DebugTexts>
      <TextConfig crc32="0x12345678" washa="0xFFFFFFFF">
        <String textNumber="0" varianceKey="0" value="Debug message 1" />
      </TextConfig>
    </DebugTexts>
</Root>
```
---

**Adding Speakers with `characters.txt`**

> **Note:** Attaching and customizing character speaker entries is **exclusively supported for the `Cfg bin + Text Config` format**, which is only used in **Inazuma Eleven GO (IEGO)**.

If you want to add new speakers to Nyanko, you can create a `characters.txt` file in the root directory of the application:

```text
ID|Name
0x6B87BE96|Cryptix
```

* **ID**: The ID of the speaker, which can be in little-endian hexadecimal format (e.g., `0x6B87BE96`) or as a plain text string ID (e.g., `ev10`).
* **Name**: The display name of the speaker (e.g., `Cryptix`).

Nyanko automatically loads new speakers into the dropdown menu **at application startup**. Changes made to `characters.txt` require restarting Nyanko to take effect.

---

**Bruteforcing Key Names (CRC32 Finder)**

Nyanko includes a tool to bruteforce and resolve raw CRC32 hash IDs back into human-readable key names (such as `ev050`, `ev100`, etc.).

1. Go to **Tools > CRC32 Finder** in the top menu bar.
2. Define your search parameters in the **Generate CRC32** window:
* **Prefix / Suffix**: Text patterns attached before or after generated numbers (e.g., Prefix: `ev`).
* **Min / Max / Step / Padding**: Defines the numerical loop range, increment step, and leading zeros padding (e.g., Min `0`, Max `500`, Step `10`, Padding `3` generates `ev000`, `ev010`, `ev020`, ...).
<img width="486" height="235" alt="image" src="https://github.com/user-attachments/assets/a2764fec-90c1-4918-93cc-e59a625c1f1f" />

3. Click **Generate** to match calculated hashes against missing text entries.

<img width="1913" height="1029" alt="image" src="https://github.com/user-attachments/assets/63f71a6e-1390-4355-a19c-75a77efd3b8f" />

Resolved string key names can be **saved inside the `cfg.bin` file**. When enabled, reopening the file in Nyanko displays text string IDs in the TreeView instead of raw CRC32 values.

---

**Command Line Arguments (CLI)**

Nyanko can be executed with command-line arguments for quick file loading, automated conversions, or immediate UI navigation.

**1. Direct File Launch**

```bash
Nyanko.exe [file_path]

```

* Attempts to open the application and load the specified file directly.
* If the file format is unsupported or an error occurs during loading, no error dialog is displayed; Nyanko simply launches normally in standard mode without any file opened.
* *Example:* `Nyanko.exe test.txt`

**2. Command Options & Aliases**

| Argument | Long Alias | Description |
| --- | --- | --- |
| `-c` | `--convert` | Converts the input file directly. Expects a `[mode]` parameter. |
| `-vk` | `--varianceKey` | Enables variance key handling during conversion. |
| `-lk` | `--listKey` | Saves string key names directly into the `.cfg.bin` file. |
| `-o` | `--output` | Specifies the custom output file path. |
| `-l` | `--lock` | Opens file in GUI and locks default save format. Incompatible with `-c`. |
| `-g` | `--goto` | Opens file in GUI and navigates to a specific node. Incompatible with `-c`. |

**Modes (used with `-c` or `-l`):**

* `b` / `binary`: Standard binary `.cfg.bin` format.
* `bt` / `binaryTextConfig`: Binary `.cfg.bin` format with Text Config support.
* `x` / `xml`: XML format.
* `t` / `txt`: TXT format.

**Argument Rules & Precedence**

* Argument order does not matter **except**:
* The **input file path** must always be the first argument.
* The **mode** value must immediately follow `-c` / `--convert` or `-l` / `--lock`.
* The **output file path** must immediately follow `-o` / `--output`.

* If `-c` (`--convert`) is provided in arguments, `-l` (`--lock`) and `-g` (`--goto`) are **ignored**.
* If `-l` (`--lock`) is active, `-vk`, `-lk`, and `-o` are **ignored**.

**Conversion Examples (`-c` / `--convert`)**

* **Convert TXT to standard Binary:**
```bash
Nyanko.exe test.txt -c b

```
Converts `test.txt` directly to `test.cfg.bin` using standard binary format (without variance key, without saving key names).
* **Convert TXT to XML:**
```bash
Nyanko.exe test.txt -x
```

Converts `test.txt` directly to `test.xml`.
* **Convert Binary to TXT:**
```bash
Nyanko.exe test.cfg.bin -t
```

Converts `test.cfg.bin` directly to `test.txt`.
* **Convert TXT to Binary with Text Config support:**
```bash
Nyanko.exe test.txt -c bt
```

* **Convert with custom output path:**
```bash
Nyanko.exe test.txt -c b -o test.bin
```

Converts `test.txt` to `test.bin` using standard binary format.
* **Full conversion with variance key and saved keys:**
```bash
Nyanko.exe test.txt -c bt -vk -lk
```

Converts `test.txt` to `test.cfg.bin` with Text Config support, variance key enabled, and saves string key names into the binary.

**Lock Option (`-l` / `--lock`)**
```bash
Nyanko.exe [file_path] -l [mode]
```

Opens the file in the GUI. When the user clicks the **Save** button, the traditional "Save As" file dialog is bypassed, saving directly using the specified binary format mode. A message box still pops up to confirm successful saving.

* *Example:* `Nyanko.exe test.txt -l b` or `Nyanko.exe test.txt --lock binary`

**Goto Navigation Option (`-g` / `--goto`)**

```bash
Nyanko.exe [file_path] -g [textType] [textId] [variance]
```

Opens the application and automatically navigates to the specified node in the TreeView (switching to the appropriate TabPage and selecting the matching item with variance key support).

* **`textType`**:
* `d` / `debug`: Debug Texts
* `n` / `noun`: Nouns
* `t` / `text`: Texts

* **`textId`**: Can be a hexadecimal CRC32 hash (e.g. `0x6B87BE96`) or a text string ID (e.g. `ev10`, where the CRC32 will be automatically computed).
* **`variance`**: An integer between `0` and `2147483647` (optional, defaults to `0` if omitted).
* **Examples:**
```bash
Nyanko.exe test.cfg.bin -g n 0x6B87BE96
Nyanko.exe test.cfg.bin -g noun ev10
Nyanko.exe test.cfg.bin --goto text ev10 1
```

---

**Credits**

* [SunnyUI](https://github.com/yhuse/SunnyUI) - Used under the GPL-3.0 license for the user interface components and layout.

---

[Direct Download Link](https://github.com/Tiniifan/Nyanko/releases/latest/download/Nyanko.exe)
