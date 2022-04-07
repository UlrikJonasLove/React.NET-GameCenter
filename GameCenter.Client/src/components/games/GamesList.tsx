import { IndividualGame } from "./IndividualGame";
import { gamesListProps } from "./interface/gamesList.Model";
import css from "./css/GamesList.module.css";
import { GenericList } from "../Utils/GenericList";

export const GamesList = (props: gamesListProps) => {
    return <GenericList list={props.games}>
        <div className={css.gamesList}>
            {props.games?.map(game => 
            <IndividualGame {...game} key={game.id} />)}
        </div>
    </GenericList>
}