module Components.ControlBar

open MaterialUI.Accordion
open Feliz
open MaterialUI.Typography
open MaterialUI.TextField
open MaterialUI.FormGroup
open MaterialUI.Icons
open MaterialUI.Button


let create =
    MaterialAccordion.create[
        MaterialAccordion.defaultExpanded true
        prop.children[
            MaterialAccordionSummary.create[
                MaterialAccordionSummary.expandIcon MaterialExpandMoreIcon.create[]
                prop.children[
                    MaterialTypography.create[
                        prop.text "Enter Patient Data"
                    ]
                ]
            ]
            MaterialAccordionDetails.create[
                prop.children[
                    MaterialFormGroup.create[
                        prop.style [style.marginBottom 10]
                        prop.style []
                        MaterialFormGroup.row true
                        prop.children[
                            ControlBarSelect.create (0, 18, "Year")
                            ControlBarSelect.create (0, 11, "Month")
                            ControlBarSelect.create (0, 4, "Week")
                            ControlBarSelect.create (0, 6, "Day")
                            MaterialTextField.create[
                                MaterialTextField.label "Weight (kg)"
                                MaterialTextField.inputType "number"
                                MaterialTextField.size "small"
                                prop.min 0
                                prop.value 3
                            ]
                            MaterialTextField.create[
                                MaterialTextField.label "Length (cm)"
                                MaterialTextField.inputType "number"
                                MaterialTextField.size "small"
                                prop.min 0
                                prop.value 50
                            ]

                        ]
                    ]
                    MaterialButton.create[
                        prop.text "Clear"
                        MaterialButton.variant "contained"
                        MaterialButton.fullWidth true
                    ]
                ]
            ]
        ]
    ]