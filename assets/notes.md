## Capturing Readme Sample Screenshots

- Run `TextDecorator.Test.Readme` project inside the console application.
- Set the console font to `Cascadia Mono PL` and font-size to `36`.
- Capture rectangular region of the text output with FastStone image viewer.
- Each line in the console should amount to 36 pixels vertically.
- The width of rectangular region should be 809 pixels.
- Save the captured image.
- Selectively crop the image and apply border effect to the cropped image.
- Inside the 'Border Effects' window, select 'Shadow' effect.
- Set radius and depth to 3 pixels, background to white and shadow color to black.
- Save the image into a new file with suitable name.

## Preparing Screenshots to Capture Blinking Text

- Run the test project inside the console application.
- Use ScreenToGif software to record the console screen.
- Resize the console screen width to 830 pixels.
- Resize the console screen height to just show the lines of interest.
- Set frames-per-second to 1 and start recording.
- Make the console application window active from taskbar.
- Record for around 8 seconds.
- In ScreenToGif editor, delete all frames except for the last two ones.
- Make sure the first one of the two has bolder text than the other.
- Right click any frame in the bottom pane, and select 'Explore Folder' option.
- Copy the two PNG files from the folder to separate layers in Paint.NET.
- Add another layer with the 'Hidden' marking.
- Selective make layers visible and save them to PNG files.
- Back in ScreenToGif editor, import the two PNG files and new frames.
- Delete the old frames.
- Override the frame duration to 1000 milliseconds.
- Save the GIF file to `img` directory.
- Save the PDN file to `assets` directory.

## Updating Logo Image

- Open `assets/logo.docx` and zoom in to 300%.
- Modify the light and dark logo images.
- Copy 276x276 pixel areas in FastStone Image Viewer.
- Crop the images to 256x256 pixels.
- Save the images in files `img/logo-light.png` and `img/logo-dark.png`.
