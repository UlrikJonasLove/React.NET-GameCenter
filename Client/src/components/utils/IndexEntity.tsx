import { ReactElement } from "react"
import axios, { AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { customConfirm } from "../../helpers/customConfirm";
import { Button } from "./Button";
import { GenericList } from "./GenericList";
import { Pagination } from "./Pagination";
import { RecordsPerPageSelect } from "./RecordsPerPageSelect";

// Generic function to centralize all the index logic
export const IndexEntity = <T,>(props: indexEntityProps<T>) => {
    const [entities, setEntities] = useState<T[]>();
    const [totalAmountOfPages, setTotalAmountOfpages] = useState(0);
    const [recordsPerPage, setRecordsPerPage] = useState(5);
    const [page, setPage] = useState(1);

    useEffect(() => {
        loadGenres();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [page, recordsPerPage])

    const loadGenres = () => {
        axios.get(props.url, {
            params: {page, recordsPerPage}
        })
        .then((response: AxiosResponse<T[]>) => {
            const totalAmountOfRecords = 
                parseInt(response.headers['totalamountofrecords'], 10);
            setTotalAmountOfpages(Math.ceil(totalAmountOfRecords / recordsPerPage));
            setEntities(response.data);
        })
    }

    const deleteEntity = async (id: number) => {
        try{
            await axios.delete(`${props.url}/${id}`);
            loadGenres();
        }
        catch(error){
            if(error && error.response){
                console.log(error.response.data);
            }
        }
    }

    const buttons = (editUrl: string, title: string, buttonText: string, id: number) => <>
        <Link className="btn btn-success" to={editUrl}>Edit</Link>
        <Button className="btn btn-danger"
            onClick={() => customConfirm(() => deleteEntity(id),
            `${title}?`, `${buttonText}`)}>{buttonText}</Button>
    </> 

    return(
        <>
            <h3>{props.title}</h3>
            <Link className="btn btn-primary" to={props.createUrl}>Create {props.entityName}</Link>

            <RecordsPerPageSelect onChange={amountOfRecords => {
                setPage(1);
                setRecordsPerPage(amountOfRecords);
            }}/>

            <Pagination currentPage={page} totalAmountOfPages={totalAmountOfPages} onChange={newPage => setPage(newPage)}/>
            <GenericList list={entities}>
                <table className="table table-stripe">
                    {props.children(entities!, buttons)}
                </table>
            </GenericList>
        </>
    )
}

// Defining all the props for the IndexEntity
interface indexEntityProps<T> {
    url: string
    title: string
    createUrl: string
    entityName: string,
    children(entities: T[], buttons: (editUrl: string, title: string, buttonText: string, id: number) => ReactElement): ReactElement
}
