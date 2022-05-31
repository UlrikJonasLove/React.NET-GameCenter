import { ReactElement, useState } from "react";
import { Typeahead } from "react-bootstrap-typeahead";
import { actorGameDto } from "../actors/model/actorsDTOs.model";

export const TypeaheadActors = (props: typeaheadActorsProps) => {
    const actors: actorGameDto[] = [
        {
            id: 1, name: "Actor 1", character: "Character 1", picture: "https://i.gifer.com/ZZ5H.gif"
        },
        {
            id: 2, name: "Actor 2", character: "Character 2", picture: "https://i.gifer.com/ZZ5H.gif"
        },
        {
            id: 3, name: "Actor 3", character: "Character 3", picture: "https://i.gifer.com/ZZ5H.gif"
        },]

    const selected: actorGameDto[] = [];

    const [draggedElement, setDraggedElement] = useState<actorGameDto | undefined>(undefined);

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
            <Typeahead 
                id="typeahead"
                onChange={actors => {
                    if(props.actors.findIndex(x => x.id === actors[0].id) === -1) {
                         props.onAdd([...props.actors, actors[0]]);
                    }
                   
                    console.log(actors);
                }}
                options={actors} labelKey={actor => actor.name}
                filterBy={["name"]} placeholder="Write the name of the actor..."
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