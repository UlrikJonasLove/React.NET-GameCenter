// export interface textFieldProps {
//     field: string;
// }

import ImageField from "./ImageField";

export interface dateFieldProps{
    field: string;
    displayName: string;
}

export interface imageFieldProps{
   displayName: string; 
   imageURL?: string;
   field: string;
}

export interface markDownFieldProps{
    displayName: string;
    field: string;
}

ImageField.defaultProps = {
    imageURL: ""
}