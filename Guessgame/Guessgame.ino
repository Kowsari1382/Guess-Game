#include <Keypad.h>
#include <LiquidCrystal.h>

int Length = 3;
char keys[4][4] = {
  { '7', '8', '9', '/' },
  { '4', '5', '6', '*' },
  { '1', '2', '3', '-' },
  { '%', '0', '=', '+' }
};
byte Rows[4] = { 14, 15, 16, 17 };
byte Columns[4] = { 8, 9, 10, 11 };
Keypad keypad = Keypad(makeKeymap(keys), Rows, Columns, 4, 4);
LiquidCrystal lcd(2, 3, 4, 5, 6, 7);
void setup() {
  // put your setup code here, to run once:
  lcd.begin(16, 2);
  lcd.clear();
  randomSeed(analogRead(0));
}

void loop() {
  // put your main code here, to run repeatedly:
  int Digits[Length];
  int Remembereds[Length];
  for (int i = 0; i < Length; i++) {
    Digits[i] = random(0, 9);
  }
  lcd.print("Remember: ");
  delay(3000);
  lcd.clear();
  for (int i = 0; i < Length; i++) {
    lcd.print(Digits[i]);
    delay(1000);
    lcd.clear();
  }
  lcd.print("Write now: ");
  delay(3000);
  lcd.clear();
  int inputed = 0;
  while (inputed < Length) {
    char key = keypad.getKey();
    if (key) {
      lcd.clear();
      lcd.write(key);
      Remembereds[inputed] = key - '0';
      inputed++;
    }
  }
  lcd.clear();
  if (Digits == Remembereds) {
    Length++;
    lcd.print("Well done, it was correct.");
    delay(3000);
    lcd.clear();
  } else {
    lcd.print("It was not true. Try again.");
    delay(3000);
    lcd.clear();
  }
}
