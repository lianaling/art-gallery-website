﻿/**
 * Slice a 1-dimensional array into chunks of arrays in a 2-dimensional array
 * @param {Array<T>} arr - the input array
 * @param {number} chunkSize - desired chunk size
 * @returns {Array<Array<T>>} 2D array consisting chunks of the original array
 */
const sliceIntoChunks = (arr, chunkSize) => {
    const res = [];
    for (let i = 0; i < arr.length; i += chunkSize) {
    const chunk = arr.slice(i, i + chunkSize);
        res.push(chunk);
    }
    return res;
};