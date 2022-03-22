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
  dup isrom? if um. $20 emit exit then
  $3f emit exit
;

: dumplinehex ( addr - addr )
  dup
  $10 0 do hm. loop cr
  $10 - \ set address back $10
;
 
: dumplineasci ( addr - addr+$10)
  $10 + ;

: diffi ( addr - addr+256)
  dumplinehex
  dumplineasci
  swap drop
;

-99 dup 1+ dup 1+
