import axios, { AxiosResponse } from "axios"
import { useEffect, useState } from "react"
import ReactMarkdown from "react-markdown";
import { Link, useParams } from "react-router-dom";
import { UrlGames } from "../../constants/endpoints"
import { Loading } from "../utils/Loading";
import { coordinateDto } from "../utils/models/utils.models";
import { GameDto } from "./models/games.model";
import Map from "../utils/Map";

export const GameDetails = () => {
    const {id}: any = useParams();
    const [game, setGame] = useState<GameDto>();
    useEffect(() => {
        axios.get(`${UrlGames}/${id}`)
            .then((response: AxiosResponse<GameDto>) => {
                response.data.releaseDate = new Date(response.data.releaseDate);
                setGame(response.data);
            })
    }, [id])

    const transformCordinates = (): coordinateDto[] => {
        if(game?.gameCenters){
            const coordinates = game.gameCenters.map(gameCenter => {
                return {lat: gameCenter.latitude, lng: gameCenter.longitude, name: gameCenter.name} as coordinateDto;
            });

            return coordinates;
        }

        return [];
    }

    // the generateEmbededVideoUrl function is used to generate the url of the video
    // the url is generated using the id of the video
    // the url is then used to generate the iframe
    const generateEmbededVideoUrl = (trailer: string): string => {
        if(!trailer){
            return '';
        }

        let videoId = trailer.split('v=')[1];
        const empersandPosition = videoId?.indexOf('&');
        if(empersandPosition !== -1){
            videoId = videoId?.substring(0, empersandPosition);
        }

        return `https://www.youtube.com/embed/${videoId}`;
    }

    return (
        game ? <article>
            <h2>{game.title} ({game.releaseDate.getFullYear()})</h2>
            {game.genres?.map(genre => 
                <Link key={genre.id} style={{marginRight: '5px'}}
                    className="btn btn-primary btn-sm rounded-pill"
                    to={`/games/search?genreId=${genre.id}`}>{genre.name}</Link>)} | {game.releaseDate.toDateString()}

            <div style={{display: 'flex', marginTop: '1rem'}}>
                <span style={{display: 'inline-block', marginRight: '1rem'}}>
                    <img src={game.poster} alt={game.title} style={{width: '225px', height: '315åx'}} />
                </span>
                {game.trailer ? <div>
                    <iframe
                        title="game-trailer"
                        width="560"
                        height="315"
                        src={generateEmbededVideoUrl(game.trailer)}
                        frameBorder={0}
                        allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
                        allowFullScreen>
                    </iframe>
                </div> : null}
            </div>

            {game.summary ? <section style={{marginTop: '1rem'}}>
                    <h3>Summary</h3>
                    <div>
                        <ReactMarkdown>{game.summary}</ReactMarkdown>
                    </div>
            </section> : null}

            {game.actors && game.actors.length > 0 ?
                <section style={{marginTop: '1rem'}}>
                    <h3>Actors</h3>
                    <div style={{display: 'flex', flexDirection: 'column'}}>
                        {game.actors.map(actor => 
                            <div key={actor.id} style={{marginBottom: '2px'}}>
                                <img src={actor.picture} 
                                    alt={actor.name} 
                                    style={{width: '50px', verticalAlign: 'middle'}} />
                                <span style={{display: 'inline-block', width: '200px', marginLeft: '1rem'}}>{actor.name}</span>
                                <span style={{display: 'inline-block', width: '45px'}}>...</span>
                                <span>{actor.character}</span>
                            </div>)}
                    </div>
                </section> : null}

            {game.gameCenters && game.gameCenters.length > 0 ?
            <section>
                <h2>Available at</h2>
                <Map coordinates={transformCordinates()} readOnly={true}/>
            </section> : null}  
        </article> : <Loading />
    )
}