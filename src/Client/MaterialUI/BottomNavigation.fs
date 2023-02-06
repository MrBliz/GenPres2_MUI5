module MaterialUI.BottomNavigation

open Fable.Core.JsInterop
open Feliz

let materialBottomNavigation: obj = importDefault "@mui/material/BottomNavigation"
let materialBottomNavigationAction: obj = importDefault "@mui/material/BottomNavigationAction"

type MaterialBottomNavigation =
     static member inline showLabels (b : bool) = prop.custom("showLabels" , b)
     static member inline sx (s: (string * obj) list) = prop.custom("sx", createObj s)
     static member inline create (props: IReactProperty list) =
        Interop.reactApi.createElement(materialBottomNavigation, createObj !!props)

type MaterialBottomNavigationAction =
     static member inline label (s : string) = prop.custom("label" , s)
     static member inline icon (e : ReactElement) = prop.custom("icon" , e)
     static member inline create (props: IReactProperty list) =
        Interop.reactApi.createElement(materialBottomNavigation, createObj !!props)