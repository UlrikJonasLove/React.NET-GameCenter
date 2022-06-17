import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { UrlGames } from "../../constants/endpoints";
import { title } from "../../constants/GameCenterVariables";
import { AlertContext } from "../../helpers/alertContext";
import { GamesList } from "./GamesList";
import { LandingPageDto } from "./models/games.model";

export const LandingPage = () =>{

    document.title = `${title} - Home`;
    const [Games, setGames] = useState<LandingPageDto>({})

  useEffect(() => {
    loadData();
  }, [])

  const loadData = () => {
    axios.get(UrlGames).then((response: AxiosResponse<LandingPageDto>) => {
        setGames(response.data)
    })
  };

    return(
        <AlertContext.Provider value={() => {
            loadData();
        }}>
            <h3>Newly Releases</h3>
            <GamesList games={Games.newlyReleased}/>

            <h3>Upcoming Releases</h3>
            <GamesList games={Games.upcomingReleases}/>
        </AlertContext.Provider>
    )
}