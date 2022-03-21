Mon 21 Mar 20:01:04 UTC 2022

mecrisp-stellaris: microbit-ra

from Matthias Koch

origin https://github.com/juju2013/mecrisp-stellaris.git



Use the microUSB port of microbit v 1.5 to connect to
the host PC.

It should present as a VFAT volume to the operating system.

Mounted in linux as 'MICROBIT' and contains two files.

Copy the .hex file onto that volume.  Microbit does the rest for you.

Communicate with the mecrisp-stellaris Forth interpreter,
via USB (CDC/ACM).

END.
