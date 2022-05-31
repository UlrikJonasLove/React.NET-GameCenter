import { IndividualGame } from "./IndividualGame";
import css from "./css/GamesList.module.css";
import { GenericList } from "../utils/GenericList";
import { GameDto } from "./models/games.model";

export const GamesList = (props: gamesListProps) => {
    return <GenericList list={props.games}>
        <div className={css.gamesList}>
            {props.games?.map(game => 
            <IndividualGame {...game} key={game.id} />)}
        </div>
    </GenericList>
}

interface gamesListProps {
    games?: GameDto[];
}