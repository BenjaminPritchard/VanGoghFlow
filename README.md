# VanGoghFlow
Van Gogh Flow is a small program written for Windows 10-based computers which overlays your display with semi-transparent visualizations while you work.

The visualizations are pulled from YouTube and are user-configurable.

In addition to just being fun and beautiful, Van Go Flow is designed to help you be more creative by gently inducing connected flow states.

But don’t just take our word for it. Download Van Gogh Flow, try it for yourself, and take your creative output to a whole new level!

# Note
If you want to customize the visuals, copy the `VanGoghFlow.INI` file to the same directory where you are building the .EXE. (Look at the code in `ReadConfig`, which uses the function `AppDomain.CurrentDomain.BaseDirectory()` to look for the .INI file) 

Next step is to find a YouTube video you like, and put it into the file.

For example, if the URL for the video is: https://www.youtube.com/watch?v=v-hcGHbWFbs

The file should say:

    v-hcGHbWFbs | The Colors of the Ocean 

# Implementation Notes
Van Go Flow is a simple program implemented in C# using Visual Studio 2019. The program takes advantage of the compositing window manager present in recent versions of Microsoft Windows. It uses the cefSharp wrapper around the amazing Chromium Embedded Framework to render the YouTube videos. (The youtube videos themselves were chosen by me because I found them beautiful, but I did not create them.)

# Conclusion
Modern programming (and life in general) is a matter of standing on the shoulders of giants.

It is my hope that this simple offering can help others find enhanced creativity to utilize the treasures offered by the vistas we can now survey.


# More Information

Please see the website for more information:

https://www.kundalinisoftware.com/van-gogh-flow/

Benjamin Pritchard / Kundalini Software  
10-June-2019
