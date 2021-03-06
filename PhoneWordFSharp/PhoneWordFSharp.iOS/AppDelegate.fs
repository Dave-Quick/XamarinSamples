﻿namespace PhoneWordFSharp.iOS

open System
open UIKit
open Foundation
open Xamarin.Forms
open PhoneWordFSharp.Core
open OpenUrl
open MainPage
open Xamarin.Forms.Platform.iOS

[<assembly: Dependency(typeof<OpenUrlService>)>] do ()

[<Register("AppDelegate")>]
type AppDelegate() = 
    inherit FormsApplicationDelegate()

    override val Window = null with get, set

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching(app, options) = 
        #if DEBUG
        Xamarin.Calabash.Start()
        #endif
        
        this.Window <- new UIWindow(UIScreen.MainScreen.Bounds)
        Xamarin.Forms.Forms.Init()
        this.LoadApplication(App())
        base.FinishedLaunching(app, options)

module Main = 
    [<EntryPoint>]
    let main args = 
        UIApplication.Main(args, null, "AppDelegate")
        0