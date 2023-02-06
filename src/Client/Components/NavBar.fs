module Components.NavBar

open MaterialUI.AppBar
open MaterialUI.Box
open Feliz
open MaterialUI.Toolbar
open MaterialUI.Typography
open MaterialUI.IconButton
open MaterialUI.Icons
open MaterialUI.Button

let create =

    MaterialBox.create[
        prop.children[
            MaterialAppBar.create[
                MaterialAppBar.position "static"
                prop.children[
                    MaterialToolbar.create[
                         prop.children[
                             MaterialIconButton.create[
                                 prop.children[
                                     MaterialMenuIcon.create[]
                                 ]
                             ]
                             MaterialTypography.create[
                                 MaterialTypography.variant "h6"
                                 MaterialTypography.sx [ "flexGrow", "1" ]
                                 prop.text "GENPres"
                             ]
                             MaterialButton.create[
                                 MaterialButton.color "inherit"
                                 prop.text "Login"
                             ]
                         ]
                    ]
                ]
            ]
        ]
    ]