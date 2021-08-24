default rel

extern  puts

section .rodata
prefix      db "One for "
prefix_len  equ $ - prefix
you         db "you"
you_len     equ $ - you
suffix      db ", one for me.", 0 ; has to be null terminated - that's probably not the best solution?
suffix_len  equ $ - suffix

section .text
global two_fer
two_fer:
    ;; the first 2 parameters pass through rdi (name), rsi (buffer)
    mov rax, rdi                ; store name in rax, general use register
    mov rdi, rsi                ; store buffer in rDi, Destination register

    lea rsi, [prefix]           ; copy prefix addr
    mov rcx, prefix_len         ; set the Counter (rCx)
    rep movsb                   ; copy byte from rsi to rdi and decrement rcx
                                ; repeat until counter == 0

    cmp rax, 0                  ; check if name was provided
    jne fill_user_name          ; jump if we've got a name

    ;; name wasn't provided - we'll use the default string 'you'
    lea rsi, [you]
    mov rcx, you_len
    rep movsb

    jmp end                     ; jump over fill_user_name and go to the end, don't collect $200

fill_user_name:
    mov rsi, rax                ; copy address of 'name' arg into rsi

do_fill_user_name:
    cmp byte[rsi], 0            ; check if we run out of string (it's null terminated)
    je  end                     ; jump to the end if we're all out of string
    movsb                       ; otherwise copy rsi to rdi
    loop do_fill_user_name      ; repeat ad nauseam

end:
    lea rsi, [suffix]
    mov rcx, suffix_len
    rep movsb

    ret
