# Silent ASUS
Solution to ticking sound issue on Asus laptops

## Issue description
On my Asus ZenBook UM3402Y, whenever I play a video or audio and then pause it, I can hear a ticking sound. This ticking sound is particularly noticeable when using headphones connected via the 3.5mm audio jack. It appears that the laptop turns off the audio system entirely when no media is being played, and whenever the audio system is disabled, it produces the ticking sound.

## Solution
To keep the audio system active, *Silent ASUS.exe* plays a silent audio file in a loop. No sound is produced; the audio system stays active, and ticking sounds are eliminated.

## How to use it?

1.  Build the project using Visual Studio or download a prebuilt EXE file from this link: [Silent ASUS.exe](https://github.com/egidijusk/silent-asus/raw/main/Silent%20ASUS.exe).

2.  Paste *Silent ASUS.exe* into the Windows Startup folder located at `%appdata%\Microsoft\Windows\Start Menu\Programs\Startup`.

3.  From now on, *Silent ASUS.exe* will automatically start when Windows boots up, and you can find the app running in the taskbar.