import React from 'react';

const PopularLinkRow = ({ link }) => {
    const {url, count} = link;
    return (
        <tr>
            <td>
                <a href={url} target="_blank">
                    {url}
                </a>
            </td>
            <td>{count}</td>
        </tr>
    );
};
export default PopularLinkRow