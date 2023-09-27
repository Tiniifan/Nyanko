# [Nyanko](https://github.com/Tiniifan/Nyanko/releases/tag/latest) <img src="https://github.com/Tiniifan/Nyanko/blob/main/Nyanko/Icon/Icon.png" alt="Logo" width="5%">

__________________________________________________________________________

**What is a cfg.bin files?**

The cfg.bin files (or simply .bin files) are binary files used in Level 5's 3DS games.  
These files are compiled binaries that look like a tag structure and store various variables used by the games.
These files don't only contain values like int, float. They can contain texts data. 
Nyanko is a tool based on [CfgBinEditor](https://github.com/Tiniifan/CfgBinEditor) and Nyanko only focuses the text editing to make it easier

**Tested on**
- Inazuma Eleven Go ✅
- Yo-Kai Watch 1 ✅

**Supported files**
- .bin and .cfg.bin (Level 5)
- .txt  
  - Regular format
    ```
    Texte 1
    Texte 2
    Texte 3
    Texte 4
    Texte 5
    ```
  - Nyanko format (Nyanko always exports using this format so your file doesn't lose any data!)
    ```
    [Texts/0x05927998/0xD9CF42CC] 
    Texte 1
    Subtexte 1
    
    [Texts/0x07D4C7C1/0x1B81B43A] 
    Texte 2
    
    [Nouns/0x0616ADF6/0xD714CAFE] 
    Noun 1
    ```
- .xml
  ```xml
    <?xml version="1.0"?>
    <Texts>
     <TextConfig crc32="0x05927998" washa="0xD9CF42CC">
      <String value="Texte 1" />
      <String value="Subtexte 1" />
     </TextConfig>
     <TextConfig crc32="0x07D4C7C1" washa="0x1B81B43A">
      <String value="Texte 2" />
     </TextConfig>
    </Texts>
    <Nouns>
     <TextConfig crc32="0x36957997" washa="0xFFFFFFFF">
      <String value="Noun 1" />
     </TextConfig>
    </Nouns>
  ```

**Screenshots**

![](https://i.imgur.com/y7RoWB6.png)

[Download the Save Editor](https://github.com/Tiniifan/Nyanko/releases/download/latest/Nyanko.exe)
