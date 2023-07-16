## Capturing Sample Screenshots for Readme file

- Run `TextDecorator.Test.Readme` project.
- Set the console font to `Cascadia Mono PL` and font-size to `20`.
- Capture rectangular region of the text output with FastStone Image Viewer.
- Each line in the console should amount to 20 pixels vertically.
- The width of rectangular region should be 450 pixels.
- Save the captured image to file `assets/readme-sample-bright.png`.
- Capture rectangular region again of the dimmed text output.
- Save the captured image to file `assets/readme-sample-dim.png`.
- Open file `assets/readme-sample-bright.png` in FastStone Image Viewer.
- Use 'Crop to File' option in the crop board and save images in `assets` directory.
- Save another copy of image from `assets/readme-sample-dim.png` for blinking text.
- Use batch convert option to add 'Border Effects' to the cropped images.
- Set radius to 4 pixels and depth to 1 pixel.
- For light theme, set background color to white and shadow color to black.
- For dark theme, set background color to `rgb(13,17,23)` and shadow color to `rgb(34,39,46)`
- For light theme, set the file name to `*-light` and for dark one, set it to `*-dark`.
- Make sure the output folder is set to `img` and the output format is set to PNG.
- For the blinking text screenshots, use [https://ezgif.com/maker]().
- Upload images for bright and dim text, with bright one first in the list.
- Set per-frame duration to 100 and select 'use global map' option.
- Download the generated gif file to `img` directory.
- Do the same for dark theme screenshots.

## Updating Logo Image

- Open `assets/logo.docx` and zoom in to 300%.
- Modify the light and dark logo images.
- Copy 276x276 pixel areas in FastStone Image Viewer.
- Crop the images to 256x256 pixels.
- Save the images in files `img/logo-light.png` and `img/logo-dark.png`.
