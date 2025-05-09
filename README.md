# [Nyanko](https://github.com/Tiniifan/Nyanko/releases/latest) <img src="https://github.com/Tiniifan/Nyanko/blob/main/Nyanko/Icon/Icon.png" alt="Logo" width="5%">

---

**What is a cfg.bin files?**

The cfg.bin files (or simply .bin files) are binary files used in Level 5's 3DS games.
These files are compiled binaries that look like a tag structure and store various variables used by the games.
These files don't only contain values like int, float. They can contain texts data.
Nyanko is a tool based on [CfgBinEditor](https://github.com/Tiniifan/CfgBinEditor) and Nyanko only focuses on text editing to make it easier.

**Tested on**

* Inazuma Eleven Go ✅
* Yo-Kai Watch 1 ✅

**Supported files**

* .bin and .cfg.bin (Level 5)
* .txt

  * Regular format

    ```
    Texte 1
    Texte 2
    Texte 3
    Texte 4
    Texte 5
    ```
  * Nyanko format (Nyanko always exports using this format so your file doesn't lose any data!)

    ```
    [Texts/0x05927998/0xD9CF42CC] 
    Texte 1
    Subtexte 1

    [Texts/0x07D4C7C1/0x1B81B43A] 
    Texte 2

    [Nouns/0x0616ADF6/0xD714CAFE] 
    Noun 1
    ```
* .xml

  ```xml
  <?xml version="1.0"?>
  <Root>
  	<Texts>
  	 <TextConfig crc32="0x8A8209CC" washa="0xFFFFFFFF">
  	  <String value="Expert rappeur au grand cœur."/>
  	  <String value="Bonsoir"/>
  	 </TextConfig>
  	</Texts>
  	<Nouns>
  	 <TextConfig crc32="0x4DED3A46" washa="0xFFFFFFFF">
  	  <String value="Samguk Han"/>
  	 </TextConfig>
  	</Nouns>
  </Root>
  ```

**Adding Speakers with `characters.txt`**

If you want to add new speakers to Nyanko, you can create a `characters.txt` file in the root directory of the application. The file should have the following format:

```
ID|Name
0x6B87BE96|Cryptix
```

* **ID**: The ID of the speaker in little-endian hexadecimal format (e.g., `0x6B87BE96`).
* **Name**: The name of the speaker (e.g., `Cryptix`).

Once you've added your `characters.txt` file, Nyanko will automatically load the new speakers into the `faceComboBox` **only at the application startup**.  
This means that any changes made to the `characters.txt` file will require a restart of Nyanko to take effect.  
This allows you to easily extend the application with additional speakers.

**Screenshots**

![](https://i.imgur.com/y7RoWB6.png)

[Direct Download Link](https://github.com/Tiniifan/Nyanko/releases/latest/download/Nyanko.exe)
