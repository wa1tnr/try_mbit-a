hex
: noprint $2e emit ;

: getch ( addr -- addr+1 )
  dup \ hang onto address
  c@
  dup  $20 < if noprint drop 1 + exit then
  dup  $7e > if noprint drop 1 + exit then
  emit 1 + ;


: isram? ( addr -- bool )
  dup
  $20000000
  1 -
  >
  if
      $20004000 1 +
      <
      exit
  then
  drop
  0
  ;

: getch ( addr -- addr+1 )
  dup \ hang onto address
  c@
  dup  $20 < if noprint drop 1 + exit then
  dup  $7e > if noprint drop 1 + exit then
  emit 1 + ;


: runz ( n -- )
  0 do getch loop ;


99 98 97 1 1 1
hex
20000000
.s

