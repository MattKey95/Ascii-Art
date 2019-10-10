import cv2
import os

image_folder = 'ascii'
video_name = 'asciiVideo.mp4'

frame = cv2.imread('ascii/frame0.png')
height, width, layers = frame.shape

video = cv2.VideoWriter(video_name, 0, 30, (width,height))

for i in range(0, 6800):
    img = cv2.imread(os.path.join(image_folder,'frame'+str(i)+'.png'))
    if img is not None:
        video.write(img)

cv2.destroyAllWindows()
video.release()
print('finished')
