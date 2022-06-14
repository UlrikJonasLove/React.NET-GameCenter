import axios, {AxiosResponse} from "axios";
import { ReactElement, useState } from "react";
import { AsyncTypeahead } from "react-bootstrap-typeahead";
import { UrlActors } from "../../constants/endpoints";
import { actorGameDto } from "../actors/model/actorsDTOs.model";

export const TypeaheadActors = (props: typeaheadActorsProps) => {
    const [actors, setActors] = useState<actorGameDto[]>([])
    const [isLoading, setIsLoading] = useState(false)

    const selected: actorGameDto[] = [];

    const [draggedElement, setDraggedElement] = useState<actorGameDto | undefined>(undefined);

    const handleSearch = (query: string) => {
        setIsLoading(true);

        axios.get(`${UrlActors}/searchByName/${query}`)
            .then((response: AxiosResponse<actorGameDto[]>) => {
                setActors(response.data);
                setIsLoading(false);
            })
    }

    const handleDragStart = (actor: actorGameDto) => {
        setDraggedElement(actor);
    }

    const handleDragover = (actor: actorGameDto) => {
        if (!draggedElement) {
            return;
        }
        if (actor.id !== draggedElement.id) {
            const draggedElementIndex = props.actors.findIndex(a => a.id === draggedElement.id);
            const actorIndex = props.actors.findIndex(a => a.id === actor.id);

            const actors = [...props.actors];
            actors[actorIndex] = draggedElement;
            actors[draggedElementIndex] = actor;
            props.onAdd(actors);
        }

    }


    return (
        <div className="mb-3">
            <label>{props.displayName}</label>
            <AsyncTypeahead 
                id="typeahead"
                onChange={actors => {
                    if(props.actors.findIndex(x => x.id === actors[0].id) === -1) {
                        actors[0].character = '';
                         props.onAdd([...props.actors, actors[0]]);
                    }
                }}

                options={actors} labelKey={actor => actor.name}
                filterBy={() => true} placeholder="Write the name of the actor..."
                isLoading={isLoading}
                onSearch={handleSearch}
                minLength={1} flip={true}
                selected={selected}
                renderMenuItemChildren={actor => (
                    <>
                        <img src={actor.picture} alt={actor.name}
                            style={{
                                height: '64px',
                                marginRight: '10px',
                                width: '64px'
                            }} />
                        <span>{actor.name}</span>
                    </>
                )} />

                <ul className="list-group">
                    {props.actors.map(actor => <li className="list-group-item list-group-item-action" 
                    key={actor.id}
                    draggable={true}
                    onDragStart={() => handleDragStart(actor)}
                    onDragOver={() => handleDragover(actor)}>
                        {props.listUI(actor)}
                        <span className="badge badge-primary badge-pill pointer text-dark"
                            style={{marginLeft: "0.5rem"}}
                            onClick={() => props.onRemove(actor)}>X</span>
                    </li>)}
                </ul>
        </div>
    )
}

interface typeaheadActorsProps {
    displayName: string;
    actors: actorGameDto[];
    onAdd(actors: actorGameDto[]): void;
    onRemove(actor: actorGameDto): void;
    listUI(actor: actorGameDto): ReactElement;
}