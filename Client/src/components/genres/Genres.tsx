import { UrlGenres } from "../../constants/endpoints"
import { genreDTO } from "./models/Genres.model"
import { Delete, title } from "../../constants/GameCenterVariables"
import { IndexEntity } from "../utils/IndexEntity"

export const Genres = () => {
    document.title = `${title} - Genres`
    
    return(
        <>
            <IndexEntity<genreDTO>
                url={UrlGenres} createUrl="genres/create" title="Genres" entityName="Genre">
                {(genres, buttons) => 
                <>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name</th>
                        </tr>
                        
                    </thead>
                    <tbody>
                        {genres?.map(genre => 
                        <tr key={genre.id}>
                            <td>
                              {buttons(`genres/edit/${genre.id}`, `${Delete} ${genre.name}`, `${Delete}`, genre.id)}  
                            </td>
                            <td>
                                {genre.name}
                            </td>
                        </tr>)}
                    </tbody>
                </>}
                    
            </IndexEntity>
        </>
    )
}