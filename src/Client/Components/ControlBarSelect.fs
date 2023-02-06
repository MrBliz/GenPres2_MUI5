module Components.ControlBarSelect

open MaterialUI.Select
open MaterialUI.FormControl
open MaterialUI.InputLabel
open MaterialUI.MenuItem
open Feliz
open FSharp.Core

let create (minValue: int, maxValue: int, label: string) =
   MaterialFormControl.create[
         MaterialFormControl.variant "standard"
         MaterialFormControl.margin "normal"
         prop.children[
             MaterialInputLabel.create[
                prop.text label
             ]
             MaterialSelect.create[
                 MaterialSelect.label label
                 prop.children[
                      for i in minValue..maxValue do
                        MaterialMenuItem.create[
                            prop.text i
                            prop.value i
                        ]
                 ]
             ]
         ]
    ]