import sys
import os
from moviepy.editor import *

print()
print("This call comes from Python Script:")
print()
print ("The arguments are: " + str(sys.argv))

argvnew = sys.argv[1].replace(".part","")

video = VideoFileClip(os.path.join(argvnew))
video.audio.write_audiofile(os.path.join(argvnew.replace(".mp4", ".mp3")))

print()
print("Everything Done!")

def transform():
    pass
