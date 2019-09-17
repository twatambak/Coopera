#include <Pixy2.h>

// This is the main Pixy object 
Pixy2 pixy;

void setup() {
  Serial.begin(115200);
  pixy.init();
}

void loop() { 
  int i; 
  
  pixy.ccc.getBlocks();
  
  // If there are detect blocks, print them!
  if (pixy.ccc.numBlocks) {
    //Serial.println(pixy.ccc.numBlocks);    
    for (i = 0; i < pixy.ccc.numBlocks; i++) {
      Serial.println((String)pixy.ccc.blocks[i].m_index + '|' + (String)pixy.ccc.blocks[i].m_signature + '|' + (String)pixy.ccc.blocks[i].m_x + '|' + (String)pixy.ccc.blocks[i].m_y);
    }
  } else {
    Serial.println("Nenhum bloco sendo dectado. Sem resposta");  
  }
}
