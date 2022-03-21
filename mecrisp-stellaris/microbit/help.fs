\ helf.fs
\ Mon 21 Mar 18:10:54 UTC 2022  wa1tnr micro:bit

\ ." rvim: :map v 0i  ." ^[0jzz " cr \ align comment

\ useful words here:
\ eraseflash     reset     compiletoflash     compiletoram     compiletoram?

reset
\ xp
\ xq
: load_a ." .. " eraseflash ;
load_a
\ xa
\ xb
\ meant to give   the    eraseflash    word time to complete.

: load if compiletoram? compiletoflash then ." .. receiving ascii-uploaded forth source code.. " ;

load
\ Forth words to be stored in flash, to follow.
\ The   compiletoflash   word enables this behavior.
: beebe \ just for fun
  ." .. and now, it's Doctor Beebe .. hello, Doctor!"
  cr ;

: helpdict ( -- ) \ 19 March 2022
  cr
  ." ;------------------------------------------------------------------------------ " cr
  ." ; Common Hardware access " cr
  ." ;------------------------------------------------------------------------------ " cr
  cr
  ."         reset           ( -- ) Reset on hardware level " cr
  ."         eint?           ( -- ) Are Interrupts enabled ? " cr
  ."         nop             ( -- ) No Operation. Hook for unused handlers ! " cr
  cr
  ." ;------------------------------------------------------------------------------ " cr
  ." ; Dictionary expansion  (exactly ANS, some logical extensions) " cr
  ." ;------------------------------------------------------------------------------ " cr
  cr
  ."         align           ( -- ) Aligns dictionary pointer " cr
  ."         aligned         ( c-addr -- a-addr ) Advances to next aligned address " cr
  ."         cell+           ( x -- x+4 ) Add size of one cell " cr
  ."         cells           ( n -- 4*n ) Calculate size of n cells " cr
  cr
  ."         unused          ( -- u ) Get current amount of free memory " cr
  ."         allot           ( n -- ) Tries to advance Dictionary Pointer by n bytes " cr
  ."                                  Aborts, if not enough space available " cr
  ."         here            ( -- a-addr|c-addr ) " cr
  ."                         Gives current position in Dictionary " cr
  cr
  ."         ,               ( u|n -- ) Appends a single number to dictionary " cr
  ."         ><,             ( u|n -- ) Reverses high and low-halfword, then " cr
  ."                                      appends it to dictionary " cr
  ."         h,              ( u|n -- ) Appends a halfword to dictionary " cr
  cr
  ."         compiletoram?   ( -- ? ) Currently compiling into ram ? " cr
  ."         compiletoram    ( -- ) Makes ram   the target for compiling " cr
  ."         compiletoflash  ( -- ) Makes flash the target for compiling " cr
  cr
  ."         forgetram       ( -- ) Forget definitions in ram without a reset " cr
  cr
  ." ;------------------------------------------------------------------------------ " cr ;

: help ( -- ) \ 19 March 2022
  ."   .. from  mecrisp-stellaris/README: " cr cr
  ." ;------------------------------------------------------------------------------ " cr
  ." ; Specials for nRF51822 and Microbit " cr
  ." ;------------------------------------------------------------------------------ " cr
  cr
  ." Flash: " cr
  ."         eraseflash      ( -- ) Erases everything. Clears Ram. Restarts Forth. " cr
  helpdict ;

: hinit cr beebe cr
  ." type 'help' for help or 'words' for word list. " cr cr ;

: vers ."   mecrisp-stellaris - wa1tnr Mon 21 Mar 18:10:54 UTC 2022  wa1tnr micro:bit  r00a-ee " cr ;

: init hinit ; \ comment if auto-run is not wanted
\ END.
reset
