\ rldump.fs
\ Tue 22 Mar 12:13:42 UTC 2022

\ include dump.fs

hex
: um. ( addr -- addr+1 )
  dup
  c@
  dup $10 < if $30 emit u. 1 + exit then
  u. 1 +
;

: hm. ( addr -- )
  dup isrom? if um. exit then
  $3f emit exit
;

: pads ( n -- ) \ side-effect: padded spaces
  0 do space loop ;

: padr. ( addr -- addr ) \ side-effect: print padding to address size in digits
  \ dup .
  dup $10 < if \ single digit
      4 pads exit then
  dup $100 < if 3 pads exit then
  dup $1000 < if 2 pads exit then
  dup $40000 < if 1 pads exit then
  \ $3f emit exit \ may want a drop here somewhere
;

: dumplinehex ( addr - addr )
  padr. dup .
  $3a emit space
  dup
  4 0 do hm. loop space
  4 0 do hm. loop space space
  4 0 do hm. loop space
  4 0 do hm. loop space space
  $10 - \ set address back $10
;
 
: dumplineasci ( addr -- addr+$10)
  $10 + ;

: di ( addr - addr+$100)
  dumplinehex
  dumplineasci cr
  swap drop
;

-99 dup 1+ dup 1+
