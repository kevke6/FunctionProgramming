module Model

//
//--------Type Definitions
//

type Details = 
        { Name          : string
          Description   : string}

type RoomId =
        | RoomId of string

type Item = 
        { Details: Details
          Price : double}

type Wait = 
        | Time of int

type Exit = 
        | AllowedExit of Details * destination: RoomId
        | LockedExit of Details * key: Wait * next: Exit
        | ProductShelve of Item list
        | NoExit of Details option

type Exits = 
        { North: Exit
          South: Exit
          East: Exit
          West: Exit}

type Room = 
        { Id : RoomId
          Details: Details
          Exits: Exits}

type Inventory = 
        |Empty of Item list option
        |Filled of Item list

type Player = 
        { Details : Details
          Location: RoomId
          Inventory: Inventory 
          Payed : bool}

type World = 
        { Rooms : Map<RoomId, Room>
          Player: Player list }

//
//-------- Initial World
//

let allRooms = [
        {Id = RoomId "Hall1"
         Details = { Name = "Hall1"; Description = "This is Hall1 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = "melk"; Description = "drinken"}
                                         Price = 1.20}
                                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
                                         Price = 1.30}
                                    ])
              South = AllowedExit({Name = "Below"; Description = "Move to Hall5"}, RoomId "Hall5")
              East = AllowedExit({Name = "Right"; Description = "Move to Hall2"}, RoomId "Hall2")
              West = ProductShelve([
                                        {Details = { Name = "appel"; Description = "fruit"}
                                         Price = 3.30}
                                        {Details = { Name = "peren"; Description = "fruit"}
                                         Price = 2.30}
                                    ]) }}

        {Id = RoomId "Hall2"
         Details = { Name = "Hall2"; Description = "This is Hall2 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = "naturel"; Description = "chips"}
                                         Price = 1.30}
                                        {Details = { Name = "paprika"; Description = "chips"}
                                         Price = 1.30}
                                    ])
              South = ProductShelve([
                                        {Details = { Name = "cola"; Description = "frisdrank"}
                                         Price = 0.75}
                                        {Details = { Name = "fanta"; Description = "frisdrank"}
                                         Price = 0.75}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall3"}, RoomId "Hall3")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall1"}, RoomId "Hall1")}}

        {Id = RoomId "Hall3"
         Details = { Name = "Hall3"; Description = "This is Hall3 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = "brocoli"; Description = "groente"}
                                         Price = 2.00}
                                        {Details = { Name = "paprika"; Description = "groente"}
                                         Price = 1.00}
                                    ])
              South = ProductShelve([
                                        {Details = { Name = "dreft"; Description = "afwasmiddelen"}
                                         Price = 2.50}
                                        {Details = { Name = "bleek"; Description = "afwasmiddelen"}
                                         Price = 0.80}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall4"}, RoomId "Hall4")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall2"}, RoomId "Hall2")}}

        {Id = RoomId "Hall4"
         Details = { Name = "Hall4"; Description = "This is Hall4 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = "bruine bonen"; Description = "bonen"}
                                         Price = 1.00}
                                        {Details = { Name = "witte bonen"; Description = "bonen"}
                                         Price = 1.00}
                                    ])
              South = AllowedExit({Name = "Below"; Description = "Move to Hall8"}, RoomId "Hall8")
              East = ProductShelve([
                                        {Details = { Name = "zout"; Description = "kruiden"}
                                         Price = 0.60}
                                        {Details = { Name = "peper"; Description = "kruiden"}
                                         Price = 0.60}
                                    ])
              West = AllowedExit({Name = "Left"; Description = "Move to Hall3"}, RoomId "Hall3")}}

        {Id = RoomId "Hall5"
         Details = { Name = "Hall5"; Description = "This is Hall5 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall1"}, RoomId "Hall1")
              South = AllowedExit({Name = "Below"; Description = "Move to Hall9"}, RoomId "Hall9")
              East = AllowedExit({Name = "Right"; Description = "Move to Hall6"}, RoomId "Hall6")
              West = ProductShelve([
                                        {Details = { Name = "expresso"; Description = "koffie zak"}
                                         Price = 5.00}
                                        {Details = { Name = "latte"; Description = "koffie zak"}
                                         Price = 5.00}
                                    ]) }}

        {Id = RoomId "Hall6"
         Details = { Name = "Hall6"; Description = "This is Hall6 in the Shop!"}
         Exits = 
            { North = ProductShelve([ // geen producten denk ik
                                        {Details = { Name = "goudse 48+"; Description = "kaas"}
                                         Price = 1.30}
                                        {Details = { Name = "goudse 38+"; Description = "kaas"}
                                         Price = 1.30}
                                    ])
              South = ProductShelve([
                                        {Details = { Name = "zalm"; Description = "vis"}
                                         Price = 6.00}
                                        {Details = { Name = "haring"; Description = "vis"}
                                         Price = 5.50}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall7"}, RoomId "Hall7")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall5"}, RoomId "Hall5")}}

        {Id = RoomId "Hall7"
         Details = { Name = "Hall7"; Description = "This is Hall7 in the Shop!"}
         Exits = 
            { North = ProductShelve([ // geen producten denk ik
                                        {Details = { Name = "choco pops"; Description = "cornflakes"}
                                         Price = 2.40}
                                        {Details = { Name = "fruit loops"; Description = "cornflakes"}
                                         Price = 2.39}
                                    ])
              South = ProductShelve([
                                        {Details = { Name = "nutella"; Description = "chocolade pasta"}
                                         Price = 1.99}
                                        {Details = { Name = "duo penotti"; Description = "chocolade pasta"}
                                         Price = 2.12}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall8"}, RoomId "Hall8")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall6"}, RoomId "Hall6")}}

        {Id = RoomId "Hall8"
         Details = { Name = "Hall8"; Description = "This is Hall8 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall4"}, RoomId "Hall4")
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Entry/Exit"}, RoomId "Entry/Exit")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall7"}, RoomId "Hall7")}}

        {Id = RoomId "Hall9"
         Details = { Name = "Hall9"; Description = "This is Hall9 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall5"}, RoomId "Hall5")
              South = AllowedExit({Name = "Below"; Description = "Move to Hall13"}, RoomId "Hall13")
              East = AllowedExit({Name = "Right"; Description = "Move to Hall10"}, RoomId "Hall10")
              West = ProductShelve([
                                        {Details = { Name = "spaghetti"; Description = "pasta"}
                                         Price = 0.55}
                                        {Details = { Name = "macaroni"; Description = "pasta"}
                                         Price = 0.56}
                                    ]) }}

        {Id = RoomId "Hall10"
         Details = { Name = "Hall10"; Description = "This is Hall10 in the Shop!"}
         Exits = 
            { North = NoExit(None)//LockedExit({ Name = "Kassa 1"; Description = "This is the first counter"}, Key = 5, exit = "Entry/exit") //Kassa LockedExit
              South = ProductShelve([
                                        {Details = { Name = "ketchup"; Description = "saus"}
                                         Price = 2.59}
                                        {Details = { Name = "mayonaise"; Description = "saus"}
                                         Price = 2.79}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall11"}, RoomId "Hall11")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall9"}, RoomId "Hall9")}}

        {Id = RoomId "Hall11"
         Details = { Name = "Hall11"; Description = "This is Hall11 in the Shop!"}
         Exits = 
            { North = NoExit(None) //Kassa LockedExit
              South = ProductShelve([
                                        {Details = { Name = "brood"; Description = "bakkerij"}
                                         Price = 1.29}
                                        {Details = { Name = "broodjes"; Description = "bakkerij"}
                                         Price = 1.09}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall12"}, RoomId "Hall12")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall10"}, RoomId "Hall10")}}

        {Id = RoomId "Hall12"
         Details = { Name = "Hall12"; Description = "This is Hall12 in the Shop!"}
         Exits = 
            { North = NoExit(None) //Kassa LockedExit
              South = AllowedExit({Name = "Below"; Description = "Move to Hall16"}, RoomId "Hall16")
              East = ProductShelve([
                                        {Details = { Name = "haribo"; Description = "snoep"}
                                         Price = 1.79}
                                        {Details = { Name = "katja"; Description = "snoep"}
                                         Price = 1.99}
                                    ])
              West = AllowedExit({Name = "Left"; Description = "Move to Hall5"}, RoomId "Hall5")}}

        {Id = RoomId "Hall13"
         Details = { Name = "Hall13"; Description = "This is Hall13 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall9"}, RoomId "Hall9")
              South = ProductShelve([
                                        {Details = { Name = "kipfilet"; Description = "vlees"}
                                         Price = 2.39}
                                        {Details = { Name = "biefstuk"; Description = "vlees"}
                                         Price = 8.59}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall14"}, RoomId "Hall14")
              West = ProductShelve([
                                        {Details = { Name = "gevulde koek"; Description = "koek"}
                                         Price = 0.79}
                                        {Details = { Name = "oreo"; Description = "koek"}
                                         Price = 0.69}
                                    ]) }}

        {Id = RoomId "Hall14"
         Details = { Name = "Hall14"; Description = "This is Hall14 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = "magnum"; Description = "ijs"}
                                         Price = 2.69}
                                        {Details = { Name = "raket"; Description = "ijs"}
                                         Price = 2.29}
                                    ])
              South = ProductShelve([
                                        {Details = { Name = "franse friet"; Description = "friet"}
                                         Price = 2.99}
                                        {Details = { Name = "friet"; Description = "friet"}
                                         Price = 2.79}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall15"}, RoomId "Hall15")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall13"}, RoomId "Hall13")}}

        {Id = RoomId "Hall15"
         Details = { Name = "Hall15"; Description = "This is Hall15 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = "donuts"; Description = "snack"}
                                         Price = 1.29}
                                        {Details = { Name = "appelflap"; Description = "snack"}
                                         Price = 1.29}
                                    ])
              South = ProductShelve([
                                        {Details = { Name = "axe"; Description = "deodorant"}
                                         Price = 1.29}
                                        {Details = { Name = "nivea"; Description = "deodorant"}
                                         Price = 1.39}
                                    ])
              East = AllowedExit({Name = "Right"; Description = "Move to Hall16"}, RoomId "Hall16")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall14"}, RoomId "Hall14")}}

        {Id = RoomId "Hall16"
         Details = { Name = "Hall16"; Description = "This is Hall16 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall12"}, RoomId "Hall12")
              South = ProductShelve([
                                        {Details = { Name = "eiren"; Description = "eiren"}
                                         Price = 1.79}
                                        {Details = { Name = "scharreleiren"; Description = "eiren"}
                                         Price = 2.29}
                                    ])
              East = ProductShelve([
                                        {Details = { Name = "mona"; Description = "toetje"}
                                         Price = 2.34}
                                        {Details = { Name = "danone"; Description = "toetje"}
                                         Price = 2.16}
                                    ])
              West = AllowedExit({Name = "Left"; Description = "Move to Hall15"}, RoomId "Hall15")}}

        {Id = RoomId "Entry/Exit"
         Details = { Name = "Entry/Exit"; Description = "This is the Entry/Exit of the Shop!"}
         Exits = 
            { North = NoExit(None) //Void
              South = NoExit(None) //Void
              East = NoExit(None)  //Void
              West = AllowedExit({Name = "Left"; Description = "Move to Hall8"}, RoomId "Hall8")}}

              ]

//let Players = [
//        {Details = {Name = "Klant1"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant2"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant3"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant4"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant5"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//        {Details = {Name = "Klant6"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant7"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant8"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant9"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//
//        {Details = {Name = "Klant10"; Description = "Klant"}
//         Location = RoomId "Entry/exit"
//         Inventory = Filled [
//                        {Details = { Name = "melk"; Description = "drinken"}
//                         Price = 1.20}
//                        {Details = { Name = "sinasappelsap"; Description = "drinken"}
//                         Price = 1.30}
//                            ]
//         Payed = false}
//              ]

let Players = [for i in 0 .. 10 ->
        {Details = {Name = "Klant"+ i.ToString(); Description = "Klant"}
         Location = RoomId "Entry/exit"
         Inventory = Empty(None)
         Payed = false}
           ]

let world = allRooms, Players

//
//-------- End World
//
