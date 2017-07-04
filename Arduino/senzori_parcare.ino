#include <NewPing.h>

#define SONAR_NUM     5     // Number of sensors.
#define MAX_DISTANCE 150    // Maximum distance (in cm) to ping.
#define PING_INTERVAL 40    // Milliseconds between sensor pings (29ms is about the min to avoid cross-sensor echo).

unsigned long pingTimer[SONAR_NUM]; // Holds the times when the next ping should happen for each sensor.
unsigned int cm[SONAR_NUM];         // Where the ping distances are stored.
uint8_t currentSensor = 0;          // Keeps track of which sensor is active.

NewPing sonar[SONAR_NUM] = {     // Sensor object array.
  NewPing(3, 12, MAX_DISTANCE), // Each sensor's trigger pin, echo pin, and max distance to ping.
  NewPing(4, 11, MAX_DISTANCE),
  NewPing(5, 10, MAX_DISTANCE),
  NewPing(6, 9, MAX_DISTANCE),
  NewPing(7, 8, MAX_DISTANCE)
};

void setup() {
  Serial.begin(9600);

  while (true) {
    Serial.println("ACK,");
    delay(250);
    if (first_step()) {
      break;
    }
  }

  setPingTime();

}

void loop() {
  for (uint8_t i = 0; i < SONAR_NUM; i++) { // Loop through all the sensors.
    if (millis() >= pingTimer[i]) {         // Is it this sensor's time to ping?
      pingTimer[i] += PING_INTERVAL * SONAR_NUM;  // Set next time this sensor will be pinged.
      if (i == 0 && currentSensor == SONAR_NUM - 1) oneSensorCycle(); // Sensor ping cycle complete, do something with the results.
      sonar[currentSensor].timer_stop();          // Make sure previous timer is canceled before starting a new ping (insurance).
      currentSensor = i;                          // Sensor being accessed.
      cm[currentSensor] = 0;                      // Make distance zero in case there's no ping echo for this sensor.
      sonar[currentSensor].ping_timer(echoCheck); // Do the ping (processing continues, interrupt will call echoCheck to look for echo).
    }
  }
  // Other code that *DOESN'T* analyze ping results can go here.
  if (Serial.available() > 0) {
    if (stop_action()) {
      for (uint8_t i = 0; i < SONAR_NUM; i++) {
        sonar[i].timer_stop();
      }
      while (true) {
        if (Serial.available() > 0) {
          if (start_action()) {
            setPingTime();
            break;
          }
          delay(50);
        }
      }
    }
  }
}

void echoCheck() { // If ping received, set the sensor distance to array.
  if (sonar[currentSensor].check_timer())
    cm[currentSensor] = sonar[currentSensor].ping_result / US_ROUNDTRIP_CM;
    cm[currentSensor] = cm[currentSensor] + 1;
}

void oneSensorCycle() { // Sensor ping cycle complete, do something with the results.
  // The following code would be replaced with your code that does something with the ping results.
  Serial.print("START,");
  for (uint8_t i = 0; i < SONAR_NUM; i++) {
    Serial.print(cm[i]);
    Serial.print(",");
  }
  Serial.println("END");
}

bool first_step() {
  if (Serial.available() > 0) {
    String data = String(Serial.readString());
    data.trim();
    int j = 0;
    for (int i = 0; i < data.length(); i++) {
      if (data[i] == ',') {
        if (data.substring(j, i) == "ACK" && i - j <= 3) {
          return true;
        }
        j = i + 1;
      }
    }
  }
  return false;
}

bool stop_action() {
  String data = String(Serial.readString());
  data.trim();
  int j = 0;
  for (int i = 0; i < data.length(); i++) {
    if (data[i] == ',') {
      if (data.substring(j, i) == "STOP" && i - j <= 4) {
        return true;
      }
      j = i + 1;
    }
  }
  return false;
}

bool start_action() {
  String data = String(Serial.readString());
  data.trim();
  int j = 0;
  for (int i = 0; i < data.length(); i++) {
    if (data[i] == ',') {
      if (data.substring(j, i) == "START" && i - j <= 5) {
        return true;
      }
      j = i + 1;
    }
  }
  return false;
}

void setPingTime() {
  pingTimer[0] = millis() + 75;           // First ping starts at 75ms, gives time for the Arduino to chill before starting.
  for (uint8_t i = 1; i < SONAR_NUM; i++) // Set the starting time for each sensor.
    pingTimer[i] = pingTimer[i - 1] + PING_INTERVAL;
}

