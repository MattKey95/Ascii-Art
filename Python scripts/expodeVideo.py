import cv2
vidcap = cv2.VideoCapture('video.mp4')
success,image = vidcap.read()
count = 0
while success:
  cv2.imwrite("images/frame%d.png" % count, image)      
  success,image = vidcap.read()
  count += 1

print('finished')
