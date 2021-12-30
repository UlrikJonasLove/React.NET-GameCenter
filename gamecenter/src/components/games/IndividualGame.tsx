import { GameDTO } from "./interface/games.model";
import css from "./css/IndividualGame.module.css";

export default function IndividualGame(props: GameDTO){

    document.title = " Game Center - Game Details"
    const buildLink = () => `/game/${props.id}`
    return (
        <div className={css.game}>
            <a href={buildLink()}>
                <img alt="Poster" src={props.poster}/>
            </a>
            <p>
                <a href={buildLink()}>{props.title}</a>
            </p>
        </div>
    )
}