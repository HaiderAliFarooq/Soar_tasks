/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
$(document).ready(function() {

    $(".click-title").mouseenter( function(    e){
        e.preventDefault();
        this.style.cursor="pointer";
    });
    $(".click-title").mousedown( function(event){
        event.preventDefault();
    });

    // Ugly code while this script is shared among several pages
    try{
        refreshHitsPerSecond(true);
    } catch(e){}
    try{
        refreshResponseTimeOverTime(true);
    } catch(e){}
    try{
        refreshResponseTimePercentiles();
    } catch(e){}
});


var responseTimePercentilesInfos = {
        data: {"result": {"minY": 17.0, "minX": 0.0, "maxY": 3802.0, "series": [{"data": [[0.0, 17.0], [0.1, 17.0], [0.2, 18.0], [0.3, 18.0], [0.4, 18.0], [0.5, 18.0], [0.6, 18.0], [0.7, 18.0], [0.8, 18.0], [0.9, 18.0], [1.0, 18.0], [1.1, 18.0], [1.2, 18.0], [1.3, 18.0], [1.4, 18.0], [1.5, 18.0], [1.6, 18.0], [1.7, 18.0], [1.8, 18.0], [1.9, 18.0], [2.0, 18.0], [2.1, 18.0], [2.2, 18.0], [2.3, 18.0], [2.4, 18.0], [2.5, 18.0], [2.6, 18.0], [2.7, 18.0], [2.8, 18.0], [2.9, 18.0], [3.0, 18.0], [3.1, 18.0], [3.2, 18.0], [3.3, 18.0], [3.4, 18.0], [3.5, 18.0], [3.6, 18.0], [3.7, 18.0], [3.8, 19.0], [3.9, 19.0], [4.0, 19.0], [4.1, 19.0], [4.2, 19.0], [4.3, 19.0], [4.4, 19.0], [4.5, 19.0], [4.6, 19.0], [4.7, 19.0], [4.8, 19.0], [4.9, 19.0], [5.0, 19.0], [5.1, 19.0], [5.2, 19.0], [5.3, 19.0], [5.4, 19.0], [5.5, 19.0], [5.6, 19.0], [5.7, 19.0], [5.8, 19.0], [5.9, 19.0], [6.0, 19.0], [6.1, 19.0], [6.2, 19.0], [6.3, 19.0], [6.4, 19.0], [6.5, 19.0], [6.6, 19.0], [6.7, 19.0], [6.8, 19.0], [6.9, 19.0], [7.0, 19.0], [7.1, 19.0], [7.2, 19.0], [7.3, 19.0], [7.4, 19.0], [7.5, 19.0], [7.6, 19.0], [7.7, 19.0], [7.8, 20.0], [7.9, 20.0], [8.0, 20.0], [8.1, 20.0], [8.2, 20.0], [8.3, 20.0], [8.4, 20.0], [8.5, 20.0], [8.6, 20.0], [8.7, 20.0], [8.8, 20.0], [8.9, 20.0], [9.0, 20.0], [9.1, 20.0], [9.2, 20.0], [9.3, 20.0], [9.4, 20.0], [9.5, 20.0], [9.6, 20.0], [9.7, 20.0], [9.8, 20.0], [9.9, 20.0], [10.0, 20.0], [10.1, 20.0], [10.2, 20.0], [10.3, 21.0], [10.4, 21.0], [10.5, 21.0], [10.6, 21.0], [10.7, 21.0], [10.8, 21.0], [10.9, 21.0], [11.0, 21.0], [11.1, 21.0], [11.2, 22.0], [11.3, 22.0], [11.4, 22.0], [11.5, 22.0], [11.6, 22.0], [11.7, 22.0], [11.8, 22.0], [11.9, 22.0], [12.0, 22.0], [12.1, 22.0], [12.2, 22.0], [12.3, 22.0], [12.4, 22.0], [12.5, 23.0], [12.6, 23.0], [12.7, 23.0], [12.8, 23.0], [12.9, 23.0], [13.0, 23.0], [13.1, 23.0], [13.2, 23.0], [13.3, 23.0], [13.4, 23.0], [13.5, 23.0], [13.6, 23.0], [13.7, 23.0], [13.8, 23.0], [13.9, 23.0], [14.0, 23.0], [14.1, 23.0], [14.2, 23.0], [14.3, 23.0], [14.4, 23.0], [14.5, 23.0], [14.6, 23.0], [14.7, 23.0], [14.8, 23.0], [14.9, 23.0], [15.0, 23.0], [15.1, 23.0], [15.2, 23.0], [15.3, 23.0], [15.4, 23.0], [15.5, 23.0], [15.6, 23.0], [15.7, 23.0], [15.8, 23.0], [15.9, 23.0], [16.0, 23.0], [16.1, 23.0], [16.2, 23.0], [16.3, 23.0], [16.4, 24.0], [16.5, 24.0], [16.6, 24.0], [16.7, 24.0], [16.8, 24.0], [16.9, 24.0], [17.0, 24.0], [17.1, 24.0], [17.2, 24.0], [17.3, 24.0], [17.4, 24.0], [17.5, 24.0], [17.6, 24.0], [17.7, 24.0], [17.8, 24.0], [17.9, 24.0], [18.0, 24.0], [18.1, 24.0], [18.2, 25.0], [18.3, 25.0], [18.4, 27.0], [18.5, 27.0], [18.6, 27.0], [18.7, 27.0], [18.8, 29.0], [18.9, 29.0], [19.0, 30.0], [19.1, 30.0], [19.2, 30.0], [19.3, 31.0], [19.4, 31.0], [19.5, 31.0], [19.6, 31.0], [19.7, 32.0], [19.8, 32.0], [19.9, 32.0], [20.0, 32.0], [20.1, 33.0], [20.2, 33.0], [20.3, 34.0], [20.4, 34.0], [20.5, 34.0], [20.6, 34.0], [20.7, 34.0], [20.8, 35.0], [20.9, 35.0], [21.0, 35.0], [21.1, 35.0], [21.2, 36.0], [21.3, 36.0], [21.4, 38.0], [21.5, 38.0], [21.6, 38.0], [21.7, 38.0], [21.8, 39.0], [21.9, 40.0], [22.0, 40.0], [22.1, 45.0], [22.2, 45.0], [22.3, 45.0], [22.4, 45.0], [22.5, 46.0], [22.6, 46.0], [22.7, 46.0], [22.8, 46.0], [22.9, 46.0], [23.0, 46.0], [23.1, 46.0], [23.2, 46.0], [23.3, 46.0], [23.4, 46.0], [23.5, 46.0], [23.6, 47.0], [23.7, 47.0], [23.8, 47.0], [23.9, 47.0], [24.0, 47.0], [24.1, 47.0], [24.2, 48.0], [24.3, 48.0], [24.4, 48.0], [24.5, 48.0], [24.6, 48.0], [24.7, 48.0], [24.8, 48.0], [24.9, 49.0], [25.0, 49.0], [25.1, 49.0], [25.2, 49.0], [25.3, 50.0], [25.4, 50.0], [25.5, 50.0], [25.6, 50.0], [25.7, 50.0], [25.8, 51.0], [25.9, 51.0], [26.0, 55.0], [26.1, 55.0], [26.2, 60.0], [26.3, 60.0], [26.4, 61.0], [26.5, 61.0], [26.6, 62.0], [26.7, 62.0], [26.8, 62.0], [26.9, 62.0], [27.0, 62.0], [27.1, 62.0], [27.2, 62.0], [27.3, 62.0], [27.4, 62.0], [27.5, 62.0], [27.6, 62.0], [27.7, 62.0], [27.8, 62.0], [27.9, 62.0], [28.0, 62.0], [28.1, 62.0], [28.2, 62.0], [28.3, 63.0], [28.4, 63.0], [28.5, 63.0], [28.6, 63.0], [28.7, 63.0], [28.8, 63.0], [28.9, 63.0], [29.0, 63.0], [29.1, 63.0], [29.2, 63.0], [29.3, 63.0], [29.4, 63.0], [29.5, 63.0], [29.6, 63.0], [29.7, 64.0], [29.8, 64.0], [29.9, 64.0], [30.0, 64.0], [30.1, 65.0], [30.2, 65.0], [30.3, 65.0], [30.4, 65.0], [30.5, 65.0], [30.6, 65.0], [30.7, 66.0], [30.8, 66.0], [30.9, 66.0], [31.0, 71.0], [31.1, 71.0], [31.2, 74.0], [31.3, 74.0], [31.4, 75.0], [31.5, 75.0], [31.6, 75.0], [31.7, 75.0], [31.8, 76.0], [31.9, 76.0], [32.0, 76.0], [32.1, 77.0], [32.2, 77.0], [32.3, 77.0], [32.4, 77.0], [32.5, 77.0], [32.6, 77.0], [32.7, 77.0], [32.8, 77.0], [32.9, 77.0], [33.0, 77.0], [33.1, 77.0], [33.2, 77.0], [33.3, 77.0], [33.4, 77.0], [33.5, 77.0], [33.6, 78.0], [33.7, 78.0], [33.8, 78.0], [33.9, 78.0], [34.0, 78.0], [34.1, 78.0], [34.2, 78.0], [34.3, 78.0], [34.4, 79.0], [34.5, 79.0], [34.6, 79.0], [34.7, 80.0], [34.8, 80.0], [34.9, 80.0], [35.0, 80.0], [35.1, 80.0], [35.2, 80.0], [35.3, 81.0], [35.4, 81.0], [35.5, 81.0], [35.6, 81.0], [35.7, 82.0], [35.8, 82.0], [35.9, 83.0], [36.0, 89.0], [36.1, 89.0], [36.2, 90.0], [36.3, 90.0], [36.4, 90.0], [36.5, 90.0], [36.6, 91.0], [36.7, 91.0], [36.8, 91.0], [36.9, 91.0], [37.0, 92.0], [37.1, 92.0], [37.2, 92.0], [37.3, 92.0], [37.4, 92.0], [37.5, 92.0], [37.6, 92.0], [37.7, 92.0], [37.8, 92.0], [37.9, 92.0], [38.0, 92.0], [38.1, 92.0], [38.2, 92.0], [38.3, 92.0], [38.4, 92.0], [38.5, 92.0], [38.6, 93.0], [38.7, 93.0], [38.8, 93.0], [38.9, 93.0], [39.0, 93.0], [39.1, 93.0], [39.2, 93.0], [39.3, 93.0], [39.4, 93.0], [39.5, 93.0], [39.6, 94.0], [39.7, 94.0], [39.8, 94.0], [39.9, 94.0], [40.0, 94.0], [40.1, 94.0], [40.2, 94.0], [40.3, 94.0], [40.4, 94.0], [40.5, 95.0], [40.6, 95.0], [40.7, 95.0], [40.8, 95.0], [40.9, 95.0], [41.0, 95.0], [41.1, 96.0], [41.2, 98.0], [41.3, 98.0], [41.4, 106.0], [41.5, 106.0], [41.6, 107.0], [41.7, 107.0], [41.8, 107.0], [41.9, 107.0], [42.0, 108.0], [42.1, 108.0], [42.2, 108.0], [42.3, 108.0], [42.4, 108.0], [42.5, 109.0], [42.6, 109.0], [42.7, 109.0], [42.8, 109.0], [42.9, 110.0], [43.0, 110.0], [43.1, 110.0], [43.2, 110.0], [43.3, 111.0], [43.4, 111.0], [43.5, 111.0], [43.6, 111.0], [43.7, 111.0], [43.8, 112.0], [43.9, 112.0], [44.0, 112.0], [44.1, 112.0], [44.2, 112.0], [44.3, 112.0], [44.4, 112.0], [44.5, 112.0], [44.6, 113.0], [44.7, 113.0], [44.8, 114.0], [44.9, 114.0], [45.0, 114.0], [45.1, 116.0], [45.2, 116.0], [45.3, 117.0], [45.4, 117.0], [45.5, 119.0], [45.6, 119.0], [45.7, 122.0], [45.8, 122.0], [45.9, 122.0], [46.0, 122.0], [46.1, 123.0], [46.2, 123.0], [46.3, 123.0], [46.4, 123.0], [46.5, 123.0], [46.6, 123.0], [46.7, 123.0], [46.8, 123.0], [46.9, 123.0], [47.0, 124.0], [47.1, 124.0], [47.2, 124.0], [47.3, 124.0], [47.4, 125.0], [47.5, 125.0], [47.6, 125.0], [47.7, 125.0], [47.8, 125.0], [47.9, 125.0], [48.0, 125.0], [48.1, 125.0], [48.2, 125.0], [48.3, 126.0], [48.4, 126.0], [48.5, 126.0], [48.6, 126.0], [48.7, 126.0], [48.8, 126.0], [48.9, 126.0], [49.0, 126.0], [49.1, 126.0], [49.2, 127.0], [49.3, 127.0], [49.4, 127.0], [49.5, 127.0], [49.6, 127.0], [49.7, 127.0], [49.8, 127.0], [49.9, 127.0], [50.0, 128.0], [50.1, 128.0], [50.2, 128.0], [50.3, 129.0], [50.4, 129.0], [50.5, 131.0], [50.6, 131.0], [50.7, 131.0], [50.8, 131.0], [50.9, 132.0], [51.0, 132.0], [51.1, 136.0], [51.2, 136.0], [51.3, 137.0], [51.4, 138.0], [51.5, 138.0], [51.6, 138.0], [51.7, 138.0], [51.8, 139.0], [51.9, 139.0], [52.0, 139.0], [52.1, 139.0], [52.2, 140.0], [52.3, 140.0], [52.4, 140.0], [52.5, 140.0], [52.6, 140.0], [52.7, 141.0], [52.8, 141.0], [52.9, 141.0], [53.0, 141.0], [53.1, 142.0], [53.2, 142.0], [53.3, 142.0], [53.4, 142.0], [53.5, 142.0], [53.6, 142.0], [53.7, 143.0], [53.8, 143.0], [53.9, 144.0], [54.0, 146.0], [54.1, 146.0], [54.2, 147.0], [54.3, 147.0], [54.4, 154.0], [54.5, 154.0], [54.6, 154.0], [54.7, 154.0], [54.8, 154.0], [54.9, 154.0], [55.0, 154.0], [55.1, 154.0], [55.2, 155.0], [55.3, 155.0], [55.4, 155.0], [55.5, 155.0], [55.6, 155.0], [55.7, 155.0], [55.8, 155.0], [55.9, 155.0], [56.0, 155.0], [56.1, 156.0], [56.2, 156.0], [56.3, 156.0], [56.4, 156.0], [56.5, 158.0], [56.6, 158.0], [56.7, 158.0], [56.8, 158.0], [56.9, 158.0], [57.0, 158.0], [57.1, 158.0], [57.2, 158.0], [57.3, 158.0], [57.4, 158.0], [57.5, 158.0], [57.6, 159.0], [57.7, 159.0], [57.8, 159.0], [57.9, 160.0], [58.0, 160.0], [58.1, 161.0], [58.2, 161.0], [58.3, 163.0], [58.4, 163.0], [58.5, 164.0], [58.6, 164.0], [58.7, 169.0], [58.8, 169.0], [58.9, 169.0], [59.0, 169.0], [59.1, 169.0], [59.2, 170.0], [59.3, 170.0], [59.4, 170.0], [59.5, 170.0], [59.6, 170.0], [59.7, 170.0], [59.8, 171.0], [59.9, 171.0], [60.0, 171.0], [60.1, 171.0], [60.2, 171.0], [60.3, 171.0], [60.4, 171.0], [60.5, 171.0], [60.6, 171.0], [60.7, 171.0], [60.8, 171.0], [60.9, 172.0], [61.0, 172.0], [61.1, 172.0], [61.2, 172.0], [61.3, 172.0], [61.4, 172.0], [61.5, 172.0], [61.6, 175.0], [61.7, 175.0], [61.8, 181.0], [61.9, 181.0], [62.0, 182.0], [62.1, 182.0], [62.2, 184.0], [62.3, 184.0], [62.4, 184.0], [62.5, 184.0], [62.6, 185.0], [62.7, 185.0], [62.8, 186.0], [62.9, 186.0], [63.0, 186.0], [63.1, 186.0], [63.2, 186.0], [63.3, 186.0], [63.4, 186.0], [63.5, 186.0], [63.6, 186.0], [63.7, 187.0], [63.8, 187.0], [63.9, 187.0], [64.0, 187.0], [64.1, 188.0], [64.2, 189.0], [64.3, 189.0], [64.4, 189.0], [64.5, 189.0], [64.6, 189.0], [64.7, 189.0], [64.8, 189.0], [64.9, 189.0], [65.0, 191.0], [65.1, 191.0], [65.2, 191.0], [65.3, 191.0], [65.4, 197.0], [65.5, 198.0], [65.6, 198.0], [65.7, 198.0], [65.8, 198.0], [65.9, 198.0], [66.0, 198.0], [66.1, 199.0], [66.2, 199.0], [66.3, 201.0], [66.4, 201.0], [66.5, 202.0], [66.6, 202.0], [66.7, 202.0], [66.8, 203.0], [66.9, 203.0], [67.0, 203.0], [67.1, 203.0], [67.2, 203.0], [67.3, 203.0], [67.4, 203.0], [67.5, 203.0], [67.6, 204.0], [67.7, 204.0], [67.8, 204.0], [67.9, 204.0], [68.0, 205.0], [68.1, 206.0], [68.2, 206.0], [68.3, 207.0], [68.4, 207.0], [68.5, 214.0], [68.6, 214.0], [68.7, 215.0], [68.8, 215.0], [68.9, 216.0], [69.0, 216.0], [69.1, 216.0], [69.2, 216.0], [69.3, 216.0], [69.4, 216.0], [69.5, 216.0], [69.6, 216.0], [69.7, 216.0], [69.8, 216.0], [69.9, 216.0], [70.0, 216.0], [70.1, 216.0], [70.2, 219.0], [70.3, 219.0], [70.4, 219.0], [70.5, 219.0], [70.6, 219.0], [70.7, 219.0], [70.8, 219.0], [70.9, 221.0], [71.0, 221.0], [71.1, 222.0], [71.2, 222.0], [71.3, 225.0], [71.4, 225.0], [71.5, 229.0], [71.6, 229.0], [71.7, 229.0], [71.8, 232.0], [71.9, 232.0], [72.0, 233.0], [72.1, 233.0], [72.2, 233.0], [72.3, 233.0], [72.4, 233.0], [72.5, 233.0], [72.6, 233.0], [72.7, 233.0], [72.8, 234.0], [72.9, 234.0], [73.0, 235.0], [73.1, 235.0], [73.2, 235.0], [73.3, 236.0], [73.4, 236.0], [73.5, 236.0], [73.6, 236.0], [73.7, 237.0], [73.8, 237.0], [73.9, 237.0], [74.0, 237.0], [74.1, 237.0], [74.2, 237.0], [74.3, 237.0], [74.4, 238.0], [74.5, 238.0], [74.6, 242.0], [74.7, 242.0], [74.8, 245.0], [74.9, 245.0], [75.0, 246.0], [75.1, 246.0], [75.2, 246.0], [75.3, 246.0], [75.4, 246.0], [75.5, 246.0], [75.6, 248.0], [75.7, 248.0], [75.8, 248.0], [75.9, 249.0], [76.0, 249.0], [76.1, 249.0], [76.2, 249.0], [76.3, 249.0], [76.4, 249.0], [76.5, 249.0], [76.6, 249.0], [76.7, 250.0], [76.8, 250.0], [76.9, 250.0], [77.0, 251.0], [77.1, 251.0], [77.2, 252.0], [77.3, 252.0], [77.4, 259.0], [77.5, 259.0], [77.6, 260.0], [77.7, 260.0], [77.8, 260.0], [77.9, 260.0], [78.0, 261.0], [78.1, 261.0], [78.2, 262.0], [78.3, 263.0], [78.4, 263.0], [78.5, 264.0], [78.6, 264.0], [78.7, 264.0], [78.8, 264.0], [78.9, 264.0], [79.0, 264.0], [79.1, 265.0], [79.2, 265.0], [79.3, 266.0], [79.4, 266.0], [79.5, 268.0], [79.6, 268.0], [79.7, 268.0], [79.8, 268.0], [79.9, 268.0], [80.0, 269.0], [80.1, 269.0], [80.2, 269.0], [80.3, 269.0], [80.4, 274.0], [80.5, 274.0], [80.6, 277.0], [80.7, 277.0], [80.8, 278.0], [80.9, 284.0], [81.0, 284.0], [81.1, 291.0], [81.2, 291.0], [81.3, 294.0], [81.4, 294.0], [81.5, 294.0], [81.6, 294.0], [81.7, 295.0], [81.8, 295.0], [81.9, 296.0], [82.0, 296.0], [82.1, 304.0], [82.2, 306.0], [82.3, 306.0], [82.4, 308.0], [82.5, 308.0], [82.6, 309.0], [82.7, 309.0], [82.8, 310.0], [82.9, 310.0], [83.0, 311.0], [83.1, 311.0], [83.2, 313.0], [83.3, 313.0], [83.4, 314.0], [83.5, 324.0], [83.6, 324.0], [83.7, 325.0], [83.8, 325.0], [83.9, 325.0], [84.0, 325.0], [84.1, 325.0], [84.2, 325.0], [84.3, 326.0], [84.4, 326.0], [84.5, 329.0], [84.6, 329.0], [84.7, 330.0], [84.8, 335.0], [84.9, 335.0], [85.0, 341.0], [85.1, 341.0], [85.2, 341.0], [85.3, 341.0], [85.4, 342.0], [85.5, 342.0], [85.6, 344.0], [85.7, 344.0], [85.8, 344.0], [85.9, 346.0], [86.0, 346.0], [86.1, 354.0], [86.2, 354.0], [86.3, 358.0], [86.4, 358.0], [86.5, 358.0], [86.6, 358.0], [86.7, 361.0], [86.8, 361.0], [86.9, 361.0], [87.0, 361.0], [87.1, 362.0], [87.2, 373.0], [87.3, 373.0], [87.4, 373.0], [87.5, 373.0], [87.6, 373.0], [87.7, 373.0], [87.8, 375.0], [87.9, 375.0], [88.0, 376.0], [88.1, 376.0], [88.2, 378.0], [88.3, 378.0], [88.4, 389.0], [88.5, 389.0], [88.6, 389.0], [88.7, 393.0], [88.8, 393.0], [88.9, 394.0], [89.0, 394.0], [89.1, 398.0], [89.2, 398.0], [89.3, 403.0], [89.4, 403.0], [89.5, 404.0], [89.6, 404.0], [89.7, 404.0], [89.8, 409.0], [89.9, 409.0], [90.0, 415.0], [90.1, 415.0], [90.2, 417.0], [90.3, 417.0], [90.4, 418.0], [90.5, 418.0], [90.6, 424.0], [90.7, 424.0], [90.8, 427.0], [90.9, 427.0], [91.0, 428.0], [91.1, 430.0], [91.2, 430.0], [91.3, 433.0], [91.4, 433.0], [91.5, 436.0], [91.6, 436.0], [91.7, 437.0], [91.8, 437.0], [91.9, 438.0], [92.0, 438.0], [92.1, 441.0], [92.2, 441.0], [92.3, 446.0], [92.4, 448.0], [92.5, 448.0], [92.6, 451.0], [92.7, 451.0], [92.8, 469.0], [92.9, 469.0], [93.0, 470.0], [93.1, 470.0], [93.2, 472.0], [93.3, 472.0], [93.4, 479.0], [93.5, 479.0], [93.6, 482.0], [93.7, 497.0], [93.8, 497.0], [93.9, 528.0], [94.0, 528.0], [94.1, 530.0], [94.2, 530.0], [94.3, 531.0], [94.4, 531.0], [94.5, 534.0], [94.6, 534.0], [94.7, 535.0], [94.8, 535.0], [94.9, 545.0], [95.0, 547.0], [95.1, 547.0], [95.2, 547.0], [95.3, 547.0], [95.4, 559.0], [95.5, 559.0], [95.6, 579.0], [95.7, 579.0], [95.8, 626.0], [95.9, 626.0], [96.0, 630.0], [96.1, 630.0], [96.2, 634.0], [96.3, 641.0], [96.4, 641.0], [96.5, 654.0], [96.6, 654.0], [96.7, 661.0], [96.8, 661.0], [96.9, 674.0], [97.0, 674.0], [97.1, 750.0], [97.2, 750.0], [97.3, 830.0], [97.4, 830.0], [97.5, 831.0], [97.6, 871.0], [97.7, 871.0], [97.8, 909.0], [97.9, 909.0], [98.0, 934.0], [98.1, 934.0], [98.2, 941.0], [98.3, 941.0], [98.4, 991.0], [98.5, 991.0], [98.6, 1079.0], [98.7, 1079.0], [98.8, 1091.0], [98.9, 1108.0], [99.0, 1108.0], [99.1, 1154.0], [99.2, 1154.0], [99.3, 1450.0], [99.4, 1450.0], [99.5, 1590.0], [99.6, 1590.0], [99.7, 1693.0], [99.8, 1693.0], [99.9, 3802.0]], "isOverall": false, "label": "Client Registration", "isController": false}], "supportsControllersDiscrimination": true, "maxX": 100.0, "title": "Response Time Percentiles"}},
        getOptions: function() {
            return {
                series: {
                    points: { show: false }
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimePercentiles'
                },
                xaxis: {
                    tickDecimals: 1,
                    axisLabel: "Percentiles",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Percentile value in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : %x.2 percentile was %y ms"
                },
                selection: { mode: "xy" },
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesResponseTimePercentiles"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimesPercentiles"), dataset, options);
            // setup overview
            $.plot($("#overviewResponseTimesPercentiles"), dataset, prepareOverviewOptions(options));
        }
};

/**
 * @param elementId Id of element where we display message
 */
function setEmptyGraph(elementId) {
    $(function() {
        $(elementId).text("No graph series with filter="+seriesFilter);
    });
}

// Response times percentiles
function refreshResponseTimePercentiles() {
    var infos = responseTimePercentilesInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyResponseTimePercentiles");
        return;
    }
    if (isGraph($("#flotResponseTimesPercentiles"))){
        infos.createGraph();
    } else {
        var choiceContainer = $("#choicesResponseTimePercentiles");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimesPercentiles", "#overviewResponseTimesPercentiles");
        $('#bodyResponseTimePercentiles .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
}

var responseTimeDistributionInfos = {
        data: {"result": {"minY": 1.0, "minX": 0.0, "maxY": 223.0, "series": [{"data": [[0.0, 223.0], [600.0, 7.0], [700.0, 1.0], [200.0, 85.0], [800.0, 3.0], [900.0, 4.0], [3800.0, 1.0], [1000.0, 2.0], [1100.0, 2.0], [300.0, 39.0], [1400.0, 1.0], [1500.0, 1.0], [100.0, 134.0], [400.0, 25.0], [1600.0, 1.0], [500.0, 10.0]], "isOverall": false, "label": "Client Registration", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 100, "maxX": 3800.0, "title": "Response Time Distribution"}},
        getOptions: function() {
            var granularity = this.data.result.granularity;
            return {
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimeDistribution'
                },
                xaxis:{
                    axisLabel: "Response times in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of responses",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                bars : {
                    show: true,
                    barWidth: this.data.result.granularity
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: function(label, xval, yval, flotItem){
                        return yval + " responses for " + label + " were between " + xval + " and " + (xval + granularity) + " ms";
                    }
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimeDistribution"), prepareData(data.result.series, $("#choicesResponseTimeDistribution")), options);
        }

};

// Response time distribution
function refreshResponseTimeDistribution() {
    var infos = responseTimeDistributionInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyResponseTimeDistribution");
        return;
    }
    if (isGraph($("#flotResponseTimeDistribution"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesResponseTimeDistribution");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        $('#footerResponseTimeDistribution .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};


var syntheticResponseTimeDistributionInfos = {
        data: {"result": {"minY": 3.0, "minX": 0.0, "ticks": [[0, "Requests having \nresponse time <= 500ms"], [1, "Requests having \nresponse time > 500ms and <= 1,500ms"], [2, "Requests having \nresponse time > 1,500ms"], [3, "Requests in error"]], "maxY": 506.0, "series": [{"data": [[0.0, 506.0]], "color": "#9ACD32", "isOverall": false, "label": "Requests having \nresponse time <= 500ms", "isController": false}, {"data": [[1.0, 30.0]], "color": "yellow", "isOverall": false, "label": "Requests having \nresponse time > 500ms and <= 1,500ms", "isController": false}, {"data": [[2.0, 3.0]], "color": "orange", "isOverall": false, "label": "Requests having \nresponse time > 1,500ms", "isController": false}, {"data": [], "color": "#FF6347", "isOverall": false, "label": "Requests in error", "isController": false}], "supportsControllersDiscrimination": false, "maxX": 2.0, "title": "Synthetic Response Times Distribution"}},
        getOptions: function() {
            return {
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendSyntheticResponseTimeDistribution'
                },
                xaxis:{
                    axisLabel: "Response times ranges",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                    tickLength:0,
                    min:-0.5,
                    max:3.5
                },
                yaxis: {
                    axisLabel: "Number of responses",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                bars : {
                    show: true,
                    align: "center",
                    barWidth: 0.25,
                    fill:.75
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: function(label, xval, yval, flotItem){
                        return yval + " " + label;
                    }
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var options = this.getOptions();
            prepareOptions(options, data);
            options.xaxis.ticks = data.result.ticks;
            $.plot($("#flotSyntheticResponseTimeDistribution"), prepareData(data.result.series, $("#choicesSyntheticResponseTimeDistribution")), options);
        }

};

// Response time distribution
function refreshSyntheticResponseTimeDistribution() {
    var infos = syntheticResponseTimeDistributionInfos;
    prepareSeries(infos.data, true);
    if (isGraph($("#flotSyntheticResponseTimeDistribution"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesSyntheticResponseTimeDistribution");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        $('#footerSyntheticResponseTimeDistribution .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var activeThreadsOverTimeInfos = {
        data: {"result": {"minY": 9.64192949907236, "minX": 1.73644602E12, "maxY": 9.64192949907236, "series": [{"data": [[1.73644602E12, 9.64192949907236]], "isOverall": false, "label": "Soar - Ultimate Thread Group", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.73644602E12, "title": "Active Threads Over Time"}},
        getOptions: function() {
            return {
                series: {
                    stack: true,
                    lines: {
                        show: true,
                        fill: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of active threads",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 6,
                    show: true,
                    container: '#legendActiveThreadsOverTime'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                selection: {
                    mode: 'xy'
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : At %x there were %y active threads"
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesActiveThreadsOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotActiveThreadsOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewActiveThreadsOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Active Threads Over Time
function refreshActiveThreadsOverTime(fixTimestamps) {
    var infos = activeThreadsOverTimeInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotActiveThreadsOverTime"))) {
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesActiveThreadsOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotActiveThreadsOverTime", "#overviewActiveThreadsOverTime");
        $('#footerActiveThreadsOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var timeVsThreadsInfos = {
        data: {"result": {"minY": 20.5, "minX": 1.0, "maxY": 531.0, "series": [{"data": [[8.0, 209.6], [4.0, 88.5], [2.0, 37.0], [1.0, 20.5], [9.0, 263.0], [10.0, 199.55952380952363], [5.0, 531.0], [6.0, 167.33333333333334], [3.0, 100.0], [7.0, 165.0]], "isOverall": false, "label": "Client Registration", "isController": false}, {"data": [[9.64192949907236, 194.64007421150262]], "isOverall": false, "label": "Client Registration-Aggregated", "isController": false}], "supportsControllersDiscrimination": true, "maxX": 10.0, "title": "Time VS Threads"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    axisLabel: "Number of active threads",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average response times in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: { noColumns: 2,show: true, container: '#legendTimeVsThreads' },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s: At %x.2 active threads, Average response time was %y.2 ms"
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesTimeVsThreads"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotTimesVsThreads"), dataset, options);
            // setup overview
            $.plot($("#overviewTimesVsThreads"), dataset, prepareOverviewOptions(options));
        }
};

// Time vs threads
function refreshTimeVsThreads(){
    var infos = timeVsThreadsInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyTimeVsThreads");
        return;
    }
    if(isGraph($("#flotTimesVsThreads"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesTimeVsThreads");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotTimesVsThreads", "#overviewTimesVsThreads");
        $('#footerTimeVsThreads .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var bytesThroughputOverTimeInfos = {
        data : {"result": {"minY": 1715.8166666666666, "minX": 1.73644602E12, "maxY": 10119.783333333333, "series": [{"data": [[1.73644602E12, 1715.8166666666666]], "isOverall": false, "label": "Bytes received per second", "isController": false}, {"data": [[1.73644602E12, 10119.783333333333]], "isOverall": false, "label": "Bytes sent per second", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.73644602E12, "title": "Bytes Throughput Over Time"}},
        getOptions : function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity) ,
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Bytes / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendBytesThroughputOverTime'
                },
                selection: {
                    mode: "xy"
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y"
                }
            };
        },
        createGraph : function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesBytesThroughputOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotBytesThroughputOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewBytesThroughputOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Bytes throughput Over Time
function refreshBytesThroughputOverTime(fixTimestamps) {
    var infos = bytesThroughputOverTimeInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotBytesThroughputOverTime"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesBytesThroughputOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotBytesThroughputOverTime", "#overviewBytesThroughputOverTime");
        $('#footerBytesThroughputOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
}

var responseTimesOverTimeInfos = {
        data: {"result": {"minY": 194.64007421150262, "minX": 1.73644602E12, "maxY": 194.64007421150262, "series": [{"data": [[1.73644602E12, 194.64007421150262]], "isOverall": false, "label": "Client Registration", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.73644602E12, "title": "Response Time Over Time"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average response time in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimesOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Average response time was %y ms"
                }
            };
        },
        createGraph: function() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesResponseTimesOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimesOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewResponseTimesOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Response Times Over Time
function refreshResponseTimeOverTime(fixTimestamps) {
    var infos = responseTimesOverTimeInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyResponseTimeOverTime");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotResponseTimesOverTime"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesResponseTimesOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimesOverTime", "#overviewResponseTimesOverTime");
        $('#footerResponseTimesOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var latenciesOverTimeInfos = {
        data: {"result": {"minY": 194.3933209647496, "minX": 1.73644602E12, "maxY": 194.3933209647496, "series": [{"data": [[1.73644602E12, 194.3933209647496]], "isOverall": false, "label": "Client Registration", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.73644602E12, "title": "Latencies Over Time"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average response latencies in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendLatenciesOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Average latency was %y ms"
                }
            };
        },
        createGraph: function () {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesLatenciesOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotLatenciesOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewLatenciesOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Latencies Over Time
function refreshLatenciesOverTime(fixTimestamps) {
    var infos = latenciesOverTimeInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyLatenciesOverTime");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotLatenciesOverTime"))) {
        infos.createGraph();
    }else {
        var choiceContainer = $("#choicesLatenciesOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotLatenciesOverTime", "#overviewLatenciesOverTime");
        $('#footerLatenciesOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var connectTimeOverTimeInfos = {
        data: {"result": {"minY": 2.435992578849722, "minX": 1.73644602E12, "maxY": 2.435992578849722, "series": [{"data": [[1.73644602E12, 2.435992578849722]], "isOverall": false, "label": "Client Registration", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.73644602E12, "title": "Connect Time Over Time"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getConnectTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Average Connect Time in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendConnectTimeOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Average connect time was %y ms"
                }
            };
        },
        createGraph: function () {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesConnectTimeOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotConnectTimeOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewConnectTimeOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Connect Time Over Time
function refreshConnectTimeOverTime(fixTimestamps) {
    var infos = connectTimeOverTimeInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyConnectTimeOverTime");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotConnectTimeOverTime"))) {
        infos.createGraph();
    }else {
        var choiceContainer = $("#choicesConnectTimeOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotConnectTimeOverTime", "#overviewConnectTimeOverTime");
        $('#footerConnectTimeOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var responseTimePercentilesOverTimeInfos = {
        data: {"result": {"minY": 17.0, "minX": 1.73644602E12, "maxY": 3802.0, "series": [{"data": [[1.73644602E12, 3802.0]], "isOverall": false, "label": "Max", "isController": false}, {"data": [[1.73644602E12, 415.0]], "isOverall": false, "label": "90th percentile", "isController": false}, {"data": [[1.73644602E12, 1135.600000000001]], "isOverall": false, "label": "99th percentile", "isController": false}, {"data": [[1.73644602E12, 547.0]], "isOverall": false, "label": "95th percentile", "isController": false}, {"data": [[1.73644602E12, 17.0]], "isOverall": false, "label": "Min", "isController": false}, {"data": [[1.73644602E12, 128.0]], "isOverall": false, "label": "Median", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.73644602E12, "title": "Response Time Percentiles Over Time (successful requests only)"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true,
                        fill: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Response Time in ms",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: '#legendResponseTimePercentilesOverTime'
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s : at %x Response time was %y ms"
                }
            };
        },
        createGraph: function () {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesResponseTimePercentilesOverTime"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotResponseTimePercentilesOverTime"), dataset, options);
            // setup overview
            $.plot($("#overviewResponseTimePercentilesOverTime"), dataset, prepareOverviewOptions(options));
        }
};

// Response Time Percentiles Over Time
function refreshResponseTimePercentilesOverTime(fixTimestamps) {
    var infos = responseTimePercentilesOverTimeInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotResponseTimePercentilesOverTime"))) {
        infos.createGraph();
    }else {
        var choiceContainer = $("#choicesResponseTimePercentilesOverTime");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimePercentilesOverTime", "#overviewResponseTimePercentilesOverTime");
        $('#footerResponseTimePercentilesOverTime .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};


var responseTimeVsRequestInfos = {
    data: {"result": {"minY": 24.0, "minX": 18.0, "maxY": 171.0, "series": [{"data": [[18.0, 150.5], [38.0, 24.0], [43.0, 114.0], [46.0, 125.5], [49.0, 171.0], [51.0, 126.0], [52.0, 162.0], [26.0, 46.0], [55.0, 141.0], [57.0, 137.0]], "isOverall": false, "label": "Successes", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 1000, "maxX": 57.0, "title": "Response Time Vs Request"}},
    getOptions: function() {
        return {
            series: {
                lines: {
                    show: false
                },
                points: {
                    show: true
                }
            },
            xaxis: {
                axisLabel: "Global number of requests per second",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            yaxis: {
                axisLabel: "Median Response Time in ms",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            legend: {
                noColumns: 2,
                show: true,
                container: '#legendResponseTimeVsRequest'
            },
            selection: {
                mode: 'xy'
            },
            grid: {
                hoverable: true // IMPORTANT! this is needed for tooltip to work
            },
            tooltip: true,
            tooltipOpts: {
                content: "%s : Median response time at %x req/s was %y ms"
            },
            colors: ["#9ACD32", "#FF6347"]
        };
    },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesResponseTimeVsRequest"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotResponseTimeVsRequest"), dataset, options);
        // setup overview
        $.plot($("#overviewResponseTimeVsRequest"), dataset, prepareOverviewOptions(options));

    }
};

// Response Time vs Request
function refreshResponseTimeVsRequest() {
    var infos = responseTimeVsRequestInfos;
    prepareSeries(infos.data);
    if (isGraph($("#flotResponseTimeVsRequest"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesResponseTimeVsRequest");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotResponseTimeVsRequest", "#overviewResponseTimeVsRequest");
        $('#footerResponseRimeVsRequest .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};


var latenciesVsRequestInfos = {
    data: {"result": {"minY": 23.5, "minX": 18.0, "maxY": 171.0, "series": [{"data": [[18.0, 150.0], [38.0, 23.5], [43.0, 114.0], [46.0, 125.0], [49.0, 171.0], [51.0, 126.0], [52.0, 162.0], [26.0, 46.0], [55.0, 140.5], [57.0, 137.0]], "isOverall": false, "label": "Successes", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 1000, "maxX": 57.0, "title": "Latencies Vs Request"}},
    getOptions: function() {
        return{
            series: {
                lines: {
                    show: false
                },
                points: {
                    show: true
                }
            },
            xaxis: {
                axisLabel: "Global number of requests per second",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            yaxis: {
                axisLabel: "Median Latency in ms",
                axisLabelUseCanvas: true,
                axisLabelFontSizePixels: 12,
                axisLabelFontFamily: 'Verdana, Arial',
                axisLabelPadding: 20,
            },
            legend: { noColumns: 2,show: true, container: '#legendLatencyVsRequest' },
            selection: {
                mode: 'xy'
            },
            grid: {
                hoverable: true // IMPORTANT! this is needed for tooltip to work
            },
            tooltip: true,
            tooltipOpts: {
                content: "%s : Median Latency time at %x req/s was %y ms"
            },
            colors: ["#9ACD32", "#FF6347"]
        };
    },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesLatencyVsRequest"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotLatenciesVsRequest"), dataset, options);
        // setup overview
        $.plot($("#overviewLatenciesVsRequest"), dataset, prepareOverviewOptions(options));
    }
};

// Latencies vs Request
function refreshLatenciesVsRequest() {
        var infos = latenciesVsRequestInfos;
        prepareSeries(infos.data);
        if(isGraph($("#flotLatenciesVsRequest"))){
            infos.createGraph();
        }else{
            var choiceContainer = $("#choicesLatencyVsRequest");
            createLegend(choiceContainer, infos);
            infos.createGraph();
            setGraphZoomable("#flotLatenciesVsRequest", "#overviewLatenciesVsRequest");
            $('#footerLatenciesVsRequest .legendColorBox > div').each(function(i){
                $(this).clone().prependTo(choiceContainer.find("li").eq(i));
            });
        }
};

var hitsPerSecondInfos = {
        data: {"result": {"minY": 8.983333333333333, "minX": 1.73644602E12, "maxY": 8.983333333333333, "series": [{"data": [[1.73644602E12, 8.983333333333333]], "isOverall": false, "label": "hitsPerSecond", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.73644602E12, "title": "Hits Per Second"}},
        getOptions: function() {
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of hits / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendHitsPerSecond"
                },
                selection: {
                    mode : 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y.2 hits/sec"
                }
            };
        },
        createGraph: function createGraph() {
            var data = this.data;
            var dataset = prepareData(data.result.series, $("#choicesHitsPerSecond"));
            var options = this.getOptions();
            prepareOptions(options, data);
            $.plot($("#flotHitsPerSecond"), dataset, options);
            // setup overview
            $.plot($("#overviewHitsPerSecond"), dataset, prepareOverviewOptions(options));
        }
};

// Hits per second
function refreshHitsPerSecond(fixTimestamps) {
    var infos = hitsPerSecondInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if (isGraph($("#flotHitsPerSecond"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesHitsPerSecond");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotHitsPerSecond", "#overviewHitsPerSecond");
        $('#footerHitsPerSecond .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
}

var codesPerSecondInfos = {
        data: {"result": {"minY": 8.983333333333333, "minX": 1.73644602E12, "maxY": 8.983333333333333, "series": [{"data": [[1.73644602E12, 8.983333333333333]], "isOverall": false, "label": "200", "isController": false}], "supportsControllersDiscrimination": false, "granularity": 60000, "maxX": 1.73644602E12, "title": "Codes Per Second"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of responses / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendCodesPerSecond"
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "Number of Response Codes %s at %x was %y.2 responses / sec"
                }
            };
        },
    createGraph: function() {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesCodesPerSecond"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotCodesPerSecond"), dataset, options);
        // setup overview
        $.plot($("#overviewCodesPerSecond"), dataset, prepareOverviewOptions(options));
    }
};

// Codes per second
function refreshCodesPerSecond(fixTimestamps) {
    var infos = codesPerSecondInfos;
    prepareSeries(infos.data);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotCodesPerSecond"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesCodesPerSecond");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotCodesPerSecond", "#overviewCodesPerSecond");
        $('#footerCodesPerSecond .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var transactionsPerSecondInfos = {
        data: {"result": {"minY": 8.983333333333333, "minX": 1.73644602E12, "maxY": 8.983333333333333, "series": [{"data": [[1.73644602E12, 8.983333333333333]], "isOverall": false, "label": "Client Registration-success", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.73644602E12, "title": "Transactions Per Second"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of transactions / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendTransactionsPerSecond"
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y transactions / sec"
                }
            };
        },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesTransactionsPerSecond"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotTransactionsPerSecond"), dataset, options);
        // setup overview
        $.plot($("#overviewTransactionsPerSecond"), dataset, prepareOverviewOptions(options));
    }
};

// Transactions per second
function refreshTransactionsPerSecond(fixTimestamps) {
    var infos = transactionsPerSecondInfos;
    prepareSeries(infos.data);
    if(infos.data.result.series.length == 0) {
        setEmptyGraph("#bodyTransactionsPerSecond");
        return;
    }
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotTransactionsPerSecond"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesTransactionsPerSecond");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotTransactionsPerSecond", "#overviewTransactionsPerSecond");
        $('#footerTransactionsPerSecond .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

var totalTPSInfos = {
        data: {"result": {"minY": 8.983333333333333, "minX": 1.73644602E12, "maxY": 8.983333333333333, "series": [{"data": [[1.73644602E12, 8.983333333333333]], "isOverall": false, "label": "Transaction-success", "isController": false}, {"data": [], "isOverall": false, "label": "Transaction-failure", "isController": false}], "supportsControllersDiscrimination": true, "granularity": 60000, "maxX": 1.73644602E12, "title": "Total Transactions Per Second"}},
        getOptions: function(){
            return {
                series: {
                    lines: {
                        show: true
                    },
                    points: {
                        show: true
                    }
                },
                xaxis: {
                    mode: "time",
                    timeformat: getTimeFormat(this.data.result.granularity),
                    axisLabel: getElapsedTimeLabel(this.data.result.granularity),
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20,
                },
                yaxis: {
                    axisLabel: "Number of transactions / sec",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Verdana, Arial',
                    axisLabelPadding: 20
                },
                legend: {
                    noColumns: 2,
                    show: true,
                    container: "#legendTotalTPS"
                },
                selection: {
                    mode: 'xy'
                },
                grid: {
                    hoverable: true // IMPORTANT! this is needed for tooltip to
                                    // work
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%s at %x was %y transactions / sec"
                },
                colors: ["#9ACD32", "#FF6347"]
            };
        },
    createGraph: function () {
        var data = this.data;
        var dataset = prepareData(data.result.series, $("#choicesTotalTPS"));
        var options = this.getOptions();
        prepareOptions(options, data);
        $.plot($("#flotTotalTPS"), dataset, options);
        // setup overview
        $.plot($("#overviewTotalTPS"), dataset, prepareOverviewOptions(options));
    }
};

// Total Transactions per second
function refreshTotalTPS(fixTimestamps) {
    var infos = totalTPSInfos;
    // We want to ignore seriesFilter
    prepareSeries(infos.data, false, true);
    if(fixTimestamps) {
        fixTimeStamps(infos.data.result.series, 18000000);
    }
    if(isGraph($("#flotTotalTPS"))){
        infos.createGraph();
    }else{
        var choiceContainer = $("#choicesTotalTPS");
        createLegend(choiceContainer, infos);
        infos.createGraph();
        setGraphZoomable("#flotTotalTPS", "#overviewTotalTPS");
        $('#footerTotalTPS .legendColorBox > div').each(function(i){
            $(this).clone().prependTo(choiceContainer.find("li").eq(i));
        });
    }
};

// Collapse the graph matching the specified DOM element depending the collapsed
// status
function collapse(elem, collapsed){
    if(collapsed){
        $(elem).parent().find(".fa-chevron-up").removeClass("fa-chevron-up").addClass("fa-chevron-down");
    } else {
        $(elem).parent().find(".fa-chevron-down").removeClass("fa-chevron-down").addClass("fa-chevron-up");
        if (elem.id == "bodyBytesThroughputOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshBytesThroughputOverTime(true);
            }
            document.location.href="#bytesThroughputOverTime";
        } else if (elem.id == "bodyLatenciesOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshLatenciesOverTime(true);
            }
            document.location.href="#latenciesOverTime";
        } else if (elem.id == "bodyCustomGraph") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshCustomGraph(true);
            }
            document.location.href="#responseCustomGraph";
        } else if (elem.id == "bodyConnectTimeOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshConnectTimeOverTime(true);
            }
            document.location.href="#connectTimeOverTime";
        } else if (elem.id == "bodyResponseTimePercentilesOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshResponseTimePercentilesOverTime(true);
            }
            document.location.href="#responseTimePercentilesOverTime";
        } else if (elem.id == "bodyResponseTimeDistribution") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshResponseTimeDistribution();
            }
            document.location.href="#responseTimeDistribution" ;
        } else if (elem.id == "bodySyntheticResponseTimeDistribution") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshSyntheticResponseTimeDistribution();
            }
            document.location.href="#syntheticResponseTimeDistribution" ;
        } else if (elem.id == "bodyActiveThreadsOverTime") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshActiveThreadsOverTime(true);
            }
            document.location.href="#activeThreadsOverTime";
        } else if (elem.id == "bodyTimeVsThreads") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshTimeVsThreads();
            }
            document.location.href="#timeVsThreads" ;
        } else if (elem.id == "bodyCodesPerSecond") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshCodesPerSecond(true);
            }
            document.location.href="#codesPerSecond";
        } else if (elem.id == "bodyTransactionsPerSecond") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshTransactionsPerSecond(true);
            }
            document.location.href="#transactionsPerSecond";
        } else if (elem.id == "bodyTotalTPS") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshTotalTPS(true);
            }
            document.location.href="#totalTPS";
        } else if (elem.id == "bodyResponseTimeVsRequest") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshResponseTimeVsRequest();
            }
            document.location.href="#responseTimeVsRequest";
        } else if (elem.id == "bodyLatenciesVsRequest") {
            if (isGraph($(elem).find('.flot-chart-content')) == false) {
                refreshLatenciesVsRequest();
            }
            document.location.href="#latencyVsRequest";
        }
    }
}

/*
 * Activates or deactivates all series of the specified graph (represented by id parameter)
 * depending on checked argument.
 */
function toggleAll(id, checked){
    var placeholder = document.getElementById(id);

    var cases = $(placeholder).find(':checkbox');
    cases.prop('checked', checked);
    $(cases).parent().children().children().toggleClass("legend-disabled", !checked);

    var choiceContainer;
    if ( id == "choicesBytesThroughputOverTime"){
        choiceContainer = $("#choicesBytesThroughputOverTime");
        refreshBytesThroughputOverTime(false);
    } else if(id == "choicesResponseTimesOverTime"){
        choiceContainer = $("#choicesResponseTimesOverTime");
        refreshResponseTimeOverTime(false);
    }else if(id == "choicesResponseCustomGraph"){
        choiceContainer = $("#choicesResponseCustomGraph");
        refreshCustomGraph(false);
    } else if ( id == "choicesLatenciesOverTime"){
        choiceContainer = $("#choicesLatenciesOverTime");
        refreshLatenciesOverTime(false);
    } else if ( id == "choicesConnectTimeOverTime"){
        choiceContainer = $("#choicesConnectTimeOverTime");
        refreshConnectTimeOverTime(false);
    } else if ( id == "choicesResponseTimePercentilesOverTime"){
        choiceContainer = $("#choicesResponseTimePercentilesOverTime");
        refreshResponseTimePercentilesOverTime(false);
    } else if ( id == "choicesResponseTimePercentiles"){
        choiceContainer = $("#choicesResponseTimePercentiles");
        refreshResponseTimePercentiles();
    } else if(id == "choicesActiveThreadsOverTime"){
        choiceContainer = $("#choicesActiveThreadsOverTime");
        refreshActiveThreadsOverTime(false);
    } else if ( id == "choicesTimeVsThreads"){
        choiceContainer = $("#choicesTimeVsThreads");
        refreshTimeVsThreads();
    } else if ( id == "choicesSyntheticResponseTimeDistribution"){
        choiceContainer = $("#choicesSyntheticResponseTimeDistribution");
        refreshSyntheticResponseTimeDistribution();
    } else if ( id == "choicesResponseTimeDistribution"){
        choiceContainer = $("#choicesResponseTimeDistribution");
        refreshResponseTimeDistribution();
    } else if ( id == "choicesHitsPerSecond"){
        choiceContainer = $("#choicesHitsPerSecond");
        refreshHitsPerSecond(false);
    } else if(id == "choicesCodesPerSecond"){
        choiceContainer = $("#choicesCodesPerSecond");
        refreshCodesPerSecond(false);
    } else if ( id == "choicesTransactionsPerSecond"){
        choiceContainer = $("#choicesTransactionsPerSecond");
        refreshTransactionsPerSecond(false);
    } else if ( id == "choicesTotalTPS"){
        choiceContainer = $("#choicesTotalTPS");
        refreshTotalTPS(false);
    } else if ( id == "choicesResponseTimeVsRequest"){
        choiceContainer = $("#choicesResponseTimeVsRequest");
        refreshResponseTimeVsRequest();
    } else if ( id == "choicesLatencyVsRequest"){
        choiceContainer = $("#choicesLatencyVsRequest");
        refreshLatenciesVsRequest();
    }
    var color = checked ? "black" : "#818181";
    if(choiceContainer != null) {
        choiceContainer.find("label").each(function(){
            this.style.color = color;
        });
    }
}

