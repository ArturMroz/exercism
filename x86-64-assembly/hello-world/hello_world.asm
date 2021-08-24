default rel

section .rodata
msg db "Hello, World!"

section .text
global hello
hello:
    lea rax, [msg]
    ret
