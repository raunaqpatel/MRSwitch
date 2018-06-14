import sys
import time
from pySpacebrew.spacebrew import Spacebrew
import RPi.GPIO as GPIO


# listen for light changes - bool
brew = Spacebrew("MRSwitch", description="Control light using mixed reality with PowerSwitch Tail 2",  server="192.168.1.165", port=9000)
brew.addSubscriber("flipLight", "boolean")
# brew.addPublisher("buttonPress", "boolean")

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
powerSwitchPin = 24
GPIO.setup(powerSwitchPin, GPIO.OUT)
GPIO.output(powerSwitchPin, GPIO.LOW)
isLightOn = False
i = 0


CHECK_FREQ = 0.1 #Sleep time for the loop


def handleBoolean(value):
    print("Received: "+str(value))
    global isLightOn
    if (value == 'true' or str(value) == 'True'):
        isLightOn = not isLightOn
        # print(str(isLightOn))
        #GPIO.output(powerSwitchPin, True)

brew.subscribe("flipLight", handleBoolean)

try:
    brew.start()
    #print("Should be looping")
    print("Press Ctrl-C to quit.")
    while True:
        # print("LOOP " + str(i))
        # i += 1
        # GPIO.output(powerSwitchPin, False)
        # if (GPIO.input(24) == False):
		#     print("Button Pushed")
		#     brew.publish('buttonPress', True)
        GPIO.output(powerSwitchPin, isLightOn)
        time.sleep(CHECK_FREQ)
    
finally:
    GPIO.cleanup()
    brew.stop()