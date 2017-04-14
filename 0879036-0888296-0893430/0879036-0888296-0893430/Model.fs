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

type Player = 
        { Details : Details
          Location: RoomId
          Inventory: Item list 
          Payed : bool}

type World = 
        { Rooms : Map<RoomId, Room>
          Player: Player list }

//
//-------- Initial World
//

let test = [
        {Details = { Name = ""; Description = ""}
         Price = 12.00}
        {Details = { Name = ""; Description = ""}
         Price = 12.00}
            ]

let allRooms = [
        {Id = RoomId "Hall1"
         Details = { Name = "Hall1"; Description = "This is Hall1 in the Shop!"}
         Exits = 
            { North = NoExit(None)
              South = AllowedExit({Name = "Below"; Description = "Move to Hall5"}, RoomId "Hall5")
              East = AllowedExit({Name = "Right"; Description = "Move to Hall2"}, RoomId "Hall2")
              West = NoExit(None) }}

        {Id = RoomId "Hall2"
         Details = { Name = "Hall2"; Description = "This is Hall2 in the Shop!"}
         Exits = 
            { North = ProductShelve([
                                        {Details = { Name = ""; Description = ""}
                                         Price = 12.00}
                                        {Details = { Name = ""; Description = ""}
                                         Price = 12.00}
                                    ])
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall3"}, RoomId "Hall3")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall1"}, RoomId "Hall1")}}

        {Id = RoomId "Hall3"
         Details = { Name = "Hall3"; Description = "This is Hall3 in the Shop!"}
         Exits = 
            { North = NoExit(None);
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall4"}, RoomId "Hall4")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall2"}, RoomId "Hall2")}}

        {Id = RoomId "Hall4"
         Details = { Name = "Hall4"; Description = "This is Hall4 in the Shop!"}
         Exits = 
            { North = NoExit(None);
              South = AllowedExit({Name = "Below"; Description = "Move to Hall8"}, RoomId "Hall8")
              East = NoExit(None)
              West = AllowedExit({Name = "Left"; Description = "Move to Hall3"}, RoomId "Hall3")}}

        {Id = RoomId "Hall5"
         Details = { Name = "Hall5"; Description = "This is Hall5 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall1"}, RoomId "Hall1")
              South = AllowedExit({Name = "Below"; Description = "Move to Hall9"}, RoomId "Hall9")
              East = AllowedExit({Name = "Right"; Description = "Move to Hall6"}, RoomId "Hall6")
              West = NoExit(None)}}

        {Id = RoomId "Hall6"
         Details = { Name = "Hall6"; Description = "This is Hall6 in the Shop!"}
         Exits = 
            { North = NoExit(None)
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall7"}, RoomId "Hall7")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall5"}, RoomId "Hall5")}}

        {Id = RoomId "Hall7"
         Details = { Name = "Hall7"; Description = "This is Hall7 in the Shop!"}
         Exits = 
            { North = NoExit(None)
              South = NoExit(None)
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
              West = NoExit(None)}}

        {Id = RoomId "Hall10"
         Details = { Name = "Hall10"; Description = "This is Hall10 in the Shop!"}
         Exits = 
            { North = NoExit(None) //Kassa LockedExit
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall11"}, RoomId "Hall11")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall9"}, RoomId "Hall9")}}

        {Id = RoomId "Hall11"
         Details = { Name = "Hall11"; Description = "This is Hall11 in the Shop!"}
         Exits = 
            { North = NoExit(None) //Kassa LockedExit
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall12"}, RoomId "Hall12")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall10"}, RoomId "Hall10")}}

        {Id = RoomId "Hall12"
         Details = { Name = "Hall12"; Description = "This is Hall12 in the Shop!"}
         Exits = 
            { North = NoExit(None) //Kassa LockedExit
              South = AllowedExit({Name = "Below"; Description = "Move to Hall16"}, RoomId "Hall16")
              East = NoExit(None)
              West = AllowedExit({Name = "Left"; Description = "Move to Hall5"}, RoomId "Hall5")}}

        {Id = RoomId "Hall13"
         Details = { Name = "Hall13"; Description = "This is Hall13 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall9"}, RoomId "Hall9")
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall14"}, RoomId "Hall14")
              West = NoExit(None)}}

        {Id = RoomId "Hall14"
         Details = { Name = "Hall14"; Description = "This is Hall14 in the Shop!"}
         Exits = 
            { North = NoExit(None)
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall15"}, RoomId "Hall15")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall13"}, RoomId "Hall13")}}

        {Id = RoomId "Hall15"
         Details = { Name = "Hall15"; Description = "This is Hall15 in the Shop!"}
         Exits = 
            { North = NoExit(None)
              South = NoExit(None)
              East = AllowedExit({Name = "Right"; Description = "Move to Hall16"}, RoomId "Hall16")
              West = AllowedExit({Name = "Left"; Description = "Move to Hall14"}, RoomId "Hall14")}}

        {Id = RoomId "Hall16"
         Details = { Name = "Hall16"; Description = "This is Hall16 in the Shop!"}
         Exits = 
            { North = AllowedExit({Name = "Up"; Description = "Move to Hall12"}, RoomId "Hall12")
              South = NoExit(None)
              East = NoExit(None)
              West = AllowedExit({Name = "Left"; Description = "Move to Hall15"}, RoomId "Hall15")}}

        {Id = RoomId "Entry/Exit"
         Details = { Name = "Entry/Exit"; Description = "This is the Entry/Exit of the Shop!"}
         Exits = 
            { North = NoExit(None) //Void
              South = NoExit(None) //Void
              East = NoExit(None)  //Void
              West = AllowedExit({Name = "Left"; Description = "Move to Hall8"}, RoomId "Hall8")}}

              ]

//
//-------- End World
//
