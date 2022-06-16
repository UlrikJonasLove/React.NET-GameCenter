import axios, { AxiosResponse } from "axios"
import { Field, Form, Formik } from "formik"
import { useEffect, useState } from "react"
import { useHistory, useLocation } from "react-router-dom"
import { UrlGames, UrlGenres } from "../../constants/endpoints"
import { genreDTO } from "../genres/models/Genres.model"
import { Button } from "../utils/Button"
import { Pagination } from "../utils/Pagination"
import { GamesList } from "./GamesList"
import { filterGamesFormDto, GameDto } from "./models/games.model"

export const FilterGame = () => {
    document.title = "Game Center - Search"
    const history = useHistory();

    const initialValue: filterGamesFormDto = {
        title: "",
        genreId: 0,
        upcomingReleases: false,
        newlyReleased: false,
        page: 1,
        recordsPerPage: 10
    }

    const [genres, setGenres] = useState<genreDTO[]>([]);
    const [games, setGames] = useState<GameDto[]>([]);
    const [totalAmountOfPages, setTotalAmountOfPages] = useState(0);
    const query = new URLSearchParams(useLocation().search);

    useEffect(() => {
        axios.get(`${UrlGenres}/all`)
            .then((response: AxiosResponse<genreDTO[]>) => {
                setGenres(response.data)
            })
    }, [])

    useEffect(() => {
        if(query.get("title")){
            initialValue.title = query.get("title")!;
        }
        if(query.get("genreId")){
            initialValue.genreId = parseInt(query.get("genreId")!, 10);
        }
        if(query.get("upcomingReleases")){
            initialValue.upcomingReleases = true;
        }
        if(query.get("newlyReleased")){
            initialValue.newlyReleased = true;
        }
        if(query.get("page")){
            initialValue.page = parseInt(query.get("page")!, 10);
        }

        searchGames(initialValue);
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[])

    const searchGames = (values: filterGamesFormDto) => {
        modifyUrl(values)
        axios.get(`${UrlGames}/filter`, {params: values})
            .then((response: AxiosResponse<GameDto[]>) => {
                const records = parseInt(response.headers["totalamountofrecords"], 10);
                setTotalAmountOfPages(Math.ceil(records / values.recordsPerPage));
                setGames(response.data)
            })
    }

    const modifyUrl = (values: filterGamesFormDto) => {
        const queryStrings: string[] = [];
        if(values.title) {
            queryStrings.push(`title=${values.title}`)
        }
        if(values.genreId !== 0) {
            queryStrings.push(`genreId=${values.genreId}`)
        }
        if(values.upcomingReleases) {
            queryStrings.push(`upcomingReleases=${values.upcomingReleases}`)
        }
        if(values.newlyReleased) {
            queryStrings.push(`newlyReleased=${values.newlyReleased}`)
        }

        queryStrings.push(`page=${values.page}`)
        history.push(`/games/search?${queryStrings.join("&")}`)
    }
    return(
        <>
            <h3>Search</h3>
            <Formik initialValues={initialValue}
            onSubmit={values => {
                values.page = 1;
                searchGames(values);
            }} 
            >{(formikProps) => (
                <>
                    <Form>
                        <div className="row gx-3 align-items-center mb-3">
                            <div className="col-auto">
                                <input type="text" className="form-control" 
                                id="title" 
                                placeholder="Title of the Game"
                                {...formikProps.getFieldProps("title")}
                                ></input>
                            </div>
                            <div className="col-auto">
                                <select className="form-select"
                                {...formikProps.getFieldProps("genreId")}>
                                    <option value="0">
                                        - Choose a Genre - 
                                    </option>
                                    {genres.map(genre => <option key={genre.id} value={genre.id}>{genre.name}</option>)}
                                </select>
                            </div>
                            <div className="col-auto">
                                <div className="form-check">
                                    <Field className="form-check-input" id="upcomingReleases" name="upcomingReleases" type="checkbox"/>
                                    <label className="form-check-label" htmlFor="upcomingReleases">Upcoming Releases</label>
                                </div>
                            </div>
                            <div className="col-auto">
                                <div className="form-check">
                                    <Field className="form-check-input" id="newlyReleases" name="newlyReleases" type="checkbox"/>
                                    <label className="form-check-label" htmlFor="newlyReleases">Newly Releases</label>
                                </div>
                            </div>
                            <div className="col-auto">
                                <Button className="btn btn-primary" onClick={() => formikProps.submitForm()}>Search</Button>
                                <Button className="btn btn-danger ms-3" onClick={() => {
                                    formikProps.setValues(initialValue);
                                    searchGames(initialValue);
                                }}>Clear</Button>
                            </div>
                        </div>
                    </Form>
                    <GamesList games={games} />
                    <Pagination 
                        totalAmountOfPages={totalAmountOfPages}
                        currentPage={formikProps.values.page}
                        onChange={newPage => {
                            formikProps.values.page = newPage;
                            searchGames(formikProps.values);
                        }} />
                </>
            )}</Formik>
        </>
    )
}