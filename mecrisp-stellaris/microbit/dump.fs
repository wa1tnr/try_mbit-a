\ dump.fs
\ Tue 22 Mar 10:15:02 UTC 2022

hex
: np. $2e emit ;

\ : getchbb ( addr -- addr+1 )
\   dup \ hang onto address
\   c@
\   dup  $20 < if noprint drop 1 + exit then
\   dup  $7e > if noprint drop 1 + exit then
\   emit 1 + ;

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
      $40000
      <
      \ ." was rom "
      exit
  then
  drop
  0
  ;

: m. ( addr -- addr+1 )
  dup
  c@
  dup  $20 < if np. drop 1 + exit then
  dup  $7e > if np. drop 1 + exit then
  emit 1 +
;

\ : runz 0 do gm. loop ; ( n -- )
\ : r 200 runz cr .s cr ;
\ decimal
\ -99 -98 -97
\ hex
\ 1 1 1
\ 20000000
\ 40000
\ .s

: gm. ( addr -- addr+1 )
  dup isram? if m. exit then
  dup isrom? if m. exit then
  $3f
  emit \ ERROR '?'
  exit
;

