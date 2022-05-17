import { Form, Formik, FormikHelpers } from "formik"
import { GameCreationDTO } from "./interface/games.model";
import * as yup from "yup"
import { Button } from "../Utils/Button";
import { Link } from "react-router-dom";
import { DateField } from "../forms/DateField";
import { TextField } from "../forms/TextField";
import { ImageField } from "../forms/ImageField";
import { CheckboxField } from "../forms/CheckboxField";
import { multipleSelectorModel, MultipleSelectors } from "../forms/MultipleSelectors";
import { useState } from "react";
import { genreDTO } from "../genres/models/GenreDTOs.model";
import { gameCenterDTO } from "../gamecenters/models/GameCenterDTO.model";
import { TypeaheadActors } from "../forms/TypeaheadActors";
import { actorGameDto } from "../actors/model/actorsDTOs.model";

export const GameForm = (props: gameFormProps) => {

    const mapToModel = (items: {id: number, name: string}[]): multipleSelectorModel[] => {
        return items.map(item => {
            return {key: item.id, value: item.name}
        })
    }

    const [selectedGameCenters, setSelectedGameCenters] = useState(mapToModel(props.selectedGameCenters))
    const [nonSelectedGameCenters, setNonSelectedGameCenters] = useState(mapToModel(props.nonSelectedGameCenters))

    const [selectedGenres, setSelectedGenres] = useState(mapToModel(props.selectedGenres))
    const [nonSelectedGenres, setNonSelectedGenres] = useState(mapToModel(props.nonSelectedGenres))

    const [selectedActors, setSelectedActors] = useState(props.selectedActors)

    return (
        <Formik
        initialValues={props.model}
        onSubmit={(values, actions) => {
            values.genresIds = selectedGenres.map(item => item.key);
            values.gameCentersIds = selectedGameCenters.map(item => item.key);
            values.actors = selectedActors;
            props.onSubmit(values, actions);
        }}
        validationSchema={yup.object({
            title: yup.string().required("This field is required").firstLetterUpperCase(),
        })}>
            {(formikProps) => (
                <Form>
                    <TextField displayName="Title" field="title" />
                    <CheckboxField displayName="Newly Released" field="newlyReleased" />
                    <TextField displayName="Trailer" field="trailer" />
                    <DateField displayName="Newly Released" field="newlyReleased" />
                    <ImageField displayName="Poster" field="poster" imageURL={props.model.posterUrl} />

                    <MultipleSelectors 
                        displayName="Genres" 
                        nonSelected={nonSelectedGenres} 
                        selected={selectedGenres}
                        onChange={(selected, nonSelected) => {
                            setSelectedGenres(selected);
                            setNonSelectedGenres(nonSelected);
                        }}/>

                        <MultipleSelectors 
                        displayName="Game Centers" 
                        nonSelected={nonSelectedGameCenters} 
                        selected={selectedGameCenters}
                        onChange={(selected, nonSelected) => {
                            setSelectedGameCenters(selected);
                            setNonSelectedGameCenters(nonSelected);
                        }}/>

                    <TypeaheadActors displayName="actors" actors={selectedActors}
                        onAdd={actors => {
                            setSelectedActors(actors);
                        }}
                        onRemove={actor => {
                            const actors = selectedActors.filter(item => item !== actor);
                            setSelectedActors(actors);
                        }}
                        
                        listUI={(actor: actorGameDto) => 
                            <>
                                {actor.name} / <input placeholder="Character" type="text" value={actor.character}
                                onChange={e => {
                                    const index = selectedActors.findIndex(item => item.id === actor.id);

                                    const actors = [...selectedActors];
                                    actors[index].character = e.target.value;
                                    setSelectedActors(actors);
                                }} />
                            </>
                        }
                        />

                    <Button disabled={formikProps.isSubmitting} type="submit">Save</Button>
                    <Link className="btn btn-danger" to="/games">Cancel</Link>
                </Form>
            )}
        </Formik>
    )
}

interface gameFormProps {
    model: GameCreationDTO;
    selectedGenres: genreDTO[];
    nonSelectedGenres: genreDTO[];
    selectedGameCenters: gameCenterDTO[];
    nonSelectedGameCenters: gameCenterDTO[];
    selectedActors: actorGameDto[];
    onSubmit(values: GameCreationDTO, actions: FormikHelpers<GameCreationDTO>): void;
}