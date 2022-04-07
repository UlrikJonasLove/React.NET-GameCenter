import { FormikHelpers } from "formik";
import { genreCreationDTO } from "../models/GenreDTOs.model";

interface genreFormProps{
    model: genreCreationDTO;
    onSubmit(values: genreCreationDTO, action: FormikHelpers<genreCreationDTO>): void;
}