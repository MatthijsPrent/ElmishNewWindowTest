namespace ElmishNewWindowTest.Gui
open System
open System.Windows
open Elmish
open Elmish.WPF

module mainModule =

    type Model = 
        {
            window: WindowState<string>
        }

    let init () = 
        {
            window = WindowState.Closed
        }, Cmd.none
    type mainmsg =
        | OpenWindow
        | CloseWindow
    
    let update msg m =
        match msg with
        | OpenWindow ->
            {m with window = m.window |> WindowState.toVisible ""} , 
            Cmd.none
        | CloseWindow ->
            {m with window = Elmish.WPF.WindowState.Closed}, 
            Cmd.none

    let subwindowBindings () =
        [
             "CloseInstrumentSetupDialog" 
             |>  Binding.cmd (CloseWindow)
        ]
    let bindings (createsetupdialog: unit -> #Window)() =
        [
            "Open" |> Binding.cmd OpenWindow
            "Close" |> Binding.cmd CloseWindow
            "subwindow" |>Binding.subModelWin(
                (fun m -> m.window),
                (subwindowBindings),
                createsetupdialog
                )
            ]

    let main window (createExtraWindow: Func<#Window>)= 
        let createDialog () =
            let window = createExtraWindow.Invoke ()
            window
        let newBindings = bindings createDialog

        WpfProgram.mkProgram init update newBindings
        |> WpfProgram.startElmishLoop window