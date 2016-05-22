# Movie/Video Capture for Unity

This is a basic implementation of a movie capture script for Unity3d. Its purpose is to generate high resolution & detail video of scripted scenes regardless of hardware specs, by capturing super sampled screenshots at a fixed frame rate. It works by leveraging the `RenderTexture` and `Texture2D` classes, as Unity's own `Application.CaptureScreenshot` clashes with post processing effects. 

![Screenshot](images/screenshot.png)

## Usage

* Attach the `MovieCapture.cs` script to an empty game object, and set the target file folder & desired framerate. 
* Set the Editor Window resolution and super sampling rate accordingly. 
    * For Instance, if the desired output is 2560x1440, you can set the Editor Window resolution to 640x360 and the Super Sampling multiplier to 4, or to 1280x720 and 2 respectively.
* Press Play
* After completion, stop execution and use any software of your choice to generate a video file from the captured screenshots.

Note that this script is only suitable for capturing scripted sequences, and not actual gameplay. Depending on your settings and hardware specifications, a few minutes long sequence could take even hours to capture.

## Disclaimer

This is only a *proof of concept* base functionality implementation of a cancelled project, and as such it lacks proper code documentation, optimization, error checking, and more advanced options. 