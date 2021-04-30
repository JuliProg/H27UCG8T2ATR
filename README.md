![Create new chip](https://github.com/JuliProg/H27UCG8T2ATR/workflows/Create%20new%20chip/badge.svg?event=repository_dispatch)
![ChipUpdate](https://github.com/JuliProg/H27UCG8T2ATR/workflows/ChipUpdate/badge.svg)
# Join the development of the project ([list of tasks](https://github.com/users/JuliProg/projects/1))


# H27UCG8T2ATR
Implementation of the H27UCG8T2ATR chip for the JuliProg programmer

Dependency injection, DI based on MEF framework is used to connect the chip to the programmer.

<section class = "listing">

# Chip parameters
```c#


        //--------------Warning!!!!!!!!!!!!!!!-------------------------------------------
        //
        //   The first operation must be a command
        //   Reset  !!!
        //
        //--------------------Vendor Specific Pin configuration---------------------------

        //  VSP1(38pin) - NC    
        //  VSP2(35pin) - NC
        //  VSP3(20pin) - NC

        ChipAssembly()
        {
            myChip.devManuf = "Hynix";
            myChip.name = "H27UCG8T2ATR";
            myChip.chipID = "ADDE94DA74C4";      // device ID

            myChip.width = Organization.x8;    // chip width - 8 bit
            myChip.bytesPP = 16384;             // page size in bytes
            myChip.spareBytesPP = 1280;          // size Spare Area in bytes
            myChip.pagesPB = 256;               // the number of pages per block 
            myChip.bloksPLUN = 2132;           // number of blocks in CE
            myChip.LUNs = 1;                   // the amount of CE in the chip
            myChip.colAdrCycles = 2;           // cycles for column addressing
            myChip.rowAdrCycles = 3;           // cycles for row addressing 
            myChip.vcc = Vcc.v3_3;             // supply voltage
        //    (myChip as ChipPrototype_v1).EccBits = 20;                // required Ecc bits for each 512 bytes
```
# Chip operations
```c#


            //------- Add chip operations    https://github.com/JuliProg/Wiki#command-set----------------------------------------------------

            myChip.Operations("Reset_FFh").
                   Operations("Erase_60h_D0h").
                   Operations("Read_00h_30h").
                   Operations("PageProgram_80h_10h");

```
# Chip registers (optional)
```c#


            //------- Add chip registers (optional)----------------------------------------------------

            myChip.registers.Add(                   // https://github.com/JuliProg/Wiki/wiki/StatusRegister
                "Status Register").
                Size(1).
                Operations("ReadStatus_70h").
                Interpretation("SR_Interpreted").
                UseAsStatusRegister();



            myChip.registers.Add(                  // https://github.com/JuliProg/Wiki/wiki/ID-Register
                "Id Register").
                Size(6).
                Operations("ReadId_90h");
            

        

```
</section>

























footer
