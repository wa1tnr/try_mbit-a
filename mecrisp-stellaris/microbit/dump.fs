\ dump.fs
\ Tue 22 Mar 01:33:37 UTC 2022

hex
: noprint $2e emit ;

: getchbb ( addr -- addr+1 )
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
      $20004000
      <
      \ ." was ram "
      exit
  then
  drop
  0
  ;

: isrom? ( addr - bool )
  \ ." entry isrom? condx: " .s ."  " cr
  dup
  0
  1 -
  > if
      $E000
      <
      \ ." was rom "
      exit
  then
  drop
  0
  ;

: goget ( addr -- addr+1 )
  dup
  c@
  dup  $20 < if noprint drop 1 + exit then
  dup  $7e > if noprint drop 1 + exit then
  emit 1 +
;

: getch ( addr -- addr+1 )
  dup isram? if goget exit then
  dup isrom? if goget exit then
  $3f
  emit \ ERROR '?'
  exit
;

: runz ( n -- )
  0 do getch loop ;

99 98 97 1 1 1
hex
20000000
.s

