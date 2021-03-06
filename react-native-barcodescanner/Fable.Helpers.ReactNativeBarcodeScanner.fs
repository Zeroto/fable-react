[<Fable.Core.Erase>]
module Fable.Helpers.ReactNativeBarcodeScanner

open Fable.Core.JsInterop
open Fable.Core
open Fable.Import
open Fable.Import.ReactNativeBarcodeScanner
type BCS = ReactNativeBarcodeScanner.Globals

module Props =

    [<KeyValueList; RequireQualifiedAccess>]
    type BarcodeScannerStyle =
        | Flex of int

    [<KeyValueList>]
    type IBarcodeScannerProperties =
        interface end

    [<KeyValueList; RequireQualifiedAccess>]
    type BarcodeScannerProperties =
    | TorchMode of TorchMode
    | CameraType of CameraType
    | Style of BarcodeScannerStyle list
        interface IBarcodeScannerProperties

open Props

/// Creates a BarcodeScanner element
let inline barcodeScanner (props:IBarcodeScannerProperties list) (onBarcodeRead: obj -> unit) : React.ReactElement<obj> = 
    React.createElement(
      BCS.BarcodeScanner,
        JS.Object.assign(
            createObj ["onBarCodeRead" ==> onBarcodeRead],
            props)
        |> unbox,
        unbox [||]) |> unbox
