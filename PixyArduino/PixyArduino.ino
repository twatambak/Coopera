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
    Serial.println(pixy.ccc.numBlocks);    
    for (i=0; i<pixy.ccc.numBlocks; i++) {
      String blocos = String(pixy.ccc.blocks[i].m_index + '|' + pixy.ccc.blocks[i].m_signature + '|' + pixy.ccc.blocks[i].m_x + '|' + pixy.ccc.blocks[i].m_y);
      //blocos.concat(pixy.ccc.blocks[i].m_index);
      //blocos.concat("|");
      //blocos.concat(pixy.ccc.blocks[i].m_signature);
      //blocos.concat("|");
      //blocos.concat(pixy.ccc.blocks[i].m_x);
      //blocos.concat("|");
      //blocos.concat(pixy.ccc.blocks[i].m_y);
      //blocos.concat("|");
      Serial.print(blocos);
    }
  }  
}
