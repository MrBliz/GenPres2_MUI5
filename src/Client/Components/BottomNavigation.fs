module Components.BottomNavigation

open MaterialUI.BottomNavigation
open MaterialUI.Box
open MaterialUI.Button
open Feliz
open MaterialUI.Icons


let create =
    MaterialBox.create[
        prop.children[
            MaterialBottomNavigation.create[
                MaterialBottomNavigation.sx ["position", "fixed"; "bottom", 0; "left", 0; "right", 0]
                MaterialBottomNavigation.showLabels true
                prop.children[
                    MaterialButton.create[
                        prop.children[
                            MaterialCopyrightIcon.create[]
                        ]
                    ]
                    MaterialButton.create[
                        prop.text "Informedica 2020"
                    ]
                    MaterialButton.create[
                        prop.children[
                            MaterialHelpIcon.create[]
                        ]
                    ]
                    MaterialButton.create[
                        prop.children[
                            MaterialGppGoodIcon.create[]
                        ]
                    ]
                ]

            ]
        ]
    ]