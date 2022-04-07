import { FormikHelpers } from "formik";
import { gameCenterCreationDTO } from "../models/GameCenterDTO.model";

export interface gameCenterForm {
    model: gameCenterCreationDTO;
    onSubmit(values: gameCenterCreationDTO, action: FormikHelpers<gameCenterCreationDTO>) : void;
}