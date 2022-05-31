import { FormikHelpers } from "formik";
import { actorCreationDTO } from "../model/actorsDTOs.model";

export interface actorFormProps {
    model: actorCreationDTO;
    onSubmit(values: actorCreationDTO, action: FormikHelpers<actorCreationDTO>) : void;
}