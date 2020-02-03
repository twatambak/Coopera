#include <Pixy2.h>

Pixy2 pixy;

void setup() {
  Serial.begin(9600);
  pixy.init();
}

void loop() {
  int i;

  pixy.ccc.getBlocks();

  if (pixy.ccc.numBlocks) {
    for (i = 0; i < pixy.ccc.numBlocks; i++) {
      Serial.println((String)pixy.ccc.blocks[i].m_signature + '|' + (String)pixy.ccc.blocks[i].m_x + '|' + (String)pixy.ccc.blocks[i].m_y + '|' + (String)pixy.ccc.blocks[i].m_width + '|' + (String)pixy.ccc.blocks[i].m_height);
    }
  }
  delay(500);
  Serial.flush();
}
