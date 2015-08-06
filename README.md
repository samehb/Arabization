# Arabization
## Introduction
The Arabization class allows the handling and conversion of Arabic texts into something that can be used by systems that do not have Arabic support. This project provides the class and an example for using it. This project and all the files included in it are released under the CC BY-NC-SA 4.0 license. 

I have developed the Arabization project back in 2010. Though, I never got around to releasing it. I wanted to release it as soon as I finished the documentation and cleaned the code. That did not happen, though. So, I am releasing it as is. I orginally developed this project for gaming consoles development. Though, it can be used with any project.

## Implementation

Arabic is an RTL (Right-to-Left) language. Also, letters in Arabic have [forms] (http://web.stanford.edu/dept/lc/arabic/alphabet/incontextletters.html) based on their locations within words. In order to implement a system that deals with Arabic strings, you would have to read the string, reverse it, process it, then connect the letters based on their location. That is simply putting it.

I started by creating some Arabic fonts using [MtkFontCreator] (http://newage.mpeg4-players.info/mt1389/tools/tools.html). Then, I developed the class which does the mentioned procedures plus providing the required mapping to the font(s). It handles English words within an Arabic string. It also handles symbols.

## How to Use

Start by creating an Arabization object:

```
Arabization ArabicText = new Arabization();
```
Read a line from the Arabic input file then call the Arabize method of the object, to process it. 
```
ArabizedLine = ArabicText.Arabize(LineToProcess);//Returns a string 
```
The Arabize method does everything and returns the converted line/string. Write the string as bytes into the output file and you are done. Refer to the project for the complete code block.

You can find the Arabic fonts under the [Fonts](Fonts) folder. Both the MtkFontCreator.ini and compiled fonts are there. latin1.mtf and latin2.mtf provide small and medium font sizes.


## Copyright
License: CC BY-NC-SA 4.0 (Attribution-NonCommercial-ShareAlike 4.0 International)

Read file [LICENSE](LICENSE)

## Links

[Blog](http://sres.tumblr.com/)
