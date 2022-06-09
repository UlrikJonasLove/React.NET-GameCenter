import { UrlGenres } from "../../constants/endpoints";
import { EditEntity } from "../utils/EditEntity";
import { GenreForm } from "./GenreForm";
import { genreCreationDTO, genreDTO } from "./models/Genres.model";

export const EditGenre = () => {
    return(
        <>
            <EditEntity<genreCreationDTO, genreDTO>
                url={UrlGenres} entityName="Genres" indexUrl="/genres">
                {(entity, edit) => 
                    <GenreForm model={entity} 
                    onSubmit={async value => {
                        await edit(value);
                    }} 
                    />
                }
            </EditEntity>
        </>
    )
}